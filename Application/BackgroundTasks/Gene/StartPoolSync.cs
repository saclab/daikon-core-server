using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Adapter.GenePool;
using Adapter.GenePool.Mycobrowser;
using Adapter.GenePool.Mycobrowser.Configuration;
using Application.BackgroundServices;
using Application.BackgroundTasks.Genes.DTO;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.AppBackgroundTasks;
using Domain.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BackgroundTasks.Genes
{
  public class StartPoolSync
  {
    public class Command : IRequest<Result<AppBackgroundTaskLog>>
    {
      public GeneSyncInitDTO GeneSyncInitDTO { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {


    }

    public class Handler : IRequestHandler<Command, Result<AppBackgroundTaskLog>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IBackgroundQueue<GenePoolBackgroundTask> _queue;
      private IMediator _mediator;

      public Handler(DataContext context, IMapper mapper, IBackgroundQueue<GenePoolBackgroundTask> queue, IMediator mediator)
      {
        _context = context;
        _mapper = mapper;
        _queue = queue;
        _mediator = mediator;
      }

      public async Task<Result<AppBackgroundTaskLog>> Handle(Command request, CancellationToken cancellationToken)
      {

        var strain = await _context.Strains.FirstOrDefaultAsync(s => s.CanonicalName == request.GeneSyncInitDTO.StrainCanonicalName);
        if (strain == null) return Result<AppBackgroundTaskLog>.Failure("Strain not found");

        var adapterConfiguration = await _context.AppConfigurations.FirstOrDefaultAsync(c => c.Key == request.GeneSyncInitDTO.AdapterConfigurationName);
        if (adapterConfiguration == null) return Result<AppBackgroundTaskLog>.Failure("Adapter Configuration not found");

        var appBackgroundTaskLog = new AppBackgroundTaskLog();


        if (request.GeneSyncInitDTO.AdapterName == "Mycobrowser")
        {
          MycobrowswerAdapterGeneSyncConfiguration mycobrowswerAdapterGeneSyncConfiguration;

          try
          {
            mycobrowswerAdapterGeneSyncConfiguration =
              JsonSerializer.Deserialize<MycobrowswerAdapterGeneSyncConfiguration>(adapterConfiguration.Value);
          }
          catch (Exception e)
          {
            return Result<AppBackgroundTaskLog>.Failure("Adapter Configuration not valid");
          }

          if (
            (mycobrowswerAdapterGeneSyncConfiguration.GeneFileURL == null)
            || (mycobrowswerAdapterGeneSyncConfiguration.GeneFASTAFileURL == null)
            || (mycobrowswerAdapterGeneSyncConfiguration.ProteinFASTAFileURL == null)
          ) return Result<AppBackgroundTaskLog>.Failure("Adapter Configuration not valid");

          appBackgroundTaskLog.Id = Guid.NewGuid();
          appBackgroundTaskLog.TaskName = "GENE_POOL_SYNC_"
                + "_" + request.GeneSyncInitDTO.StrainCanonicalName
                + "_" + request.GeneSyncInitDTO.AdapterName
                + "_" + request.GeneSyncInitDTO.AdapterConfigurationName;

          appBackgroundTaskLog.TaskStatus = "QUEUED";
          appBackgroundTaskLog.TaskType = "GENE_POOL_SYNC";
          appBackgroundTaskLog.TaskModule = "GeneSynchronizer";
          appBackgroundTaskLog.TaskSubModule = request.GeneSyncInitDTO.AdapterName;
          appBackgroundTaskLog.TaskCreated = DateTime.UtcNow;

          await _mediator.Send(new AppBackgroundTasksLog.Create.Command { AppBackgroundTaskLog = appBackgroundTaskLog });

          IGenePoolAdapter genePoolAdapter = new MycobrowserConnecter();
          
          // Set Temp Files dir
          mycobrowswerAdapterGeneSyncConfiguration.TempFilesDir = "/AppData";
          mycobrowswerAdapterGeneSyncConfiguration.StrainName = strain.CanonicalName;
          genePoolAdapter.Init(mycobrowswerAdapterGeneSyncConfiguration);


          var backgroundSyncPoolTask = new GenePoolBackgroundTask()
          {
            TaskLogId = appBackgroundTaskLog.Id,
            StrainId = strain.Id,
            AdapterConfiguration = adapterConfiguration,
            Adapter = genePoolAdapter
          };
          _queue.Enqueue(backgroundSyncPoolTask);
        }
        else
        {
          return Result<AppBackgroundTaskLog>.Failure("Adapter not found");
        }
        return Result<AppBackgroundTaskLog>.Success(appBackgroundTaskLog);

      }
    }
  }
}