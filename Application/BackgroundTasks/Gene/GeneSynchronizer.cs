using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BackgroundServices;
using Domain;
using Domain.AppBackgroundTasks;
using Domain.Tasks;
using MediatR;
using Persistence;

namespace Application.BackgroundTasks.Genes
{
  public class GeneSynchronizer : IGeneSynchronizer
  {
    private readonly DataContext _context;
    private IMediator _mediator;

    public GeneSynchronizer(DataContext context, IMediator mediator)
    {
      _context = context;
      _mediator = mediator;
    }

    public async Task SyncGenePool(GenePoolBackgroundTask task, CancellationToken cancellationToken = default)
    {
      // Update Task Log
      AppBackgroundTaskLog taskLog = _context.AppBackgroundTasksLog.FirstOrDefault(t => t.Id == task.TaskLogId);
      taskLog.TaskStatus = "RUNNING_ADAPTER";
      taskLog.TaskStartTime = DateTime.UtcNow;
      taskLog.TaskLastUpdated = DateTime.UtcNow;
      await _mediator.Send(new AppBackgroundTasksLog.Update.Command { AppBackgroundTaskLog = taskLog });



      // Get list of Gene
      List<Gene> genes = await task.Adapter.FetchGenes();

      // Update Task Log
      taskLog.TaskStatus = "IMPORTING_GENES";
      taskLog.TaskLastUpdated = DateTime.UtcNow;
      await _mediator.Send(new AppBackgroundTasksLog.Update.Command { AppBackgroundTaskLog = taskLog });

      // Now for each gene
      foreach (Gene gene in genes)
      {
        // Check if gene exists
        Gene existingGene = _context.Genes.FirstOrDefault(g => g.AccessionNumber == gene.AccessionNumber);
        if (existingGene == null)
        {
          // set the strain of the gene
          gene.StrainId = task.StrainId;
          // Create new gene
          await _mediator.Send(new Application.Genes.Create.Command { Gene = gene });

          // Create gene external Id
          await _mediator.Send(new Application.Genes.AddExternalId.Command { GeneExternalId = gene.GeneExternalIds.First() });
        }
        else
        {
          // Update existing gene
          //await _mediator.Send(new Application.Genes.Update.Command { Gene = gene });
        }
      }

      // Update Task Log
      taskLog.TaskStatus = "COMPLETED";
      taskLog.TaskEndTime = DateTime.UtcNow;
      taskLog.TaskLastUpdated = DateTime.UtcNow;
      await _mediator.Send(new AppBackgroundTasksLog.Update.Command { AppBackgroundTaskLog = taskLog });

    }
  }
}