using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Projects.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Projects
{
  public class CreateSP
  {
    public class Command : IRequest<Result<Project>>
    {
      public SPDTO SPDetails { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Project>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;

      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
      }
      public async Task<Result<Project>> Handle(Command request, CancellationToken cancellationToken)
      {

        var Project = await _context.Projects.FirstOrDefaultAsync
            (p => p.Id == request.SPDetails.Id);

        /*chek if project id is correct*/
        if (Project == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }
        if (Project.Status == ProjectStatus.Terminated.Value)
        {
          return Result<Project>.Failure("Denied : Cannot modify a terminated project");
        }


        /* check if the project is in LO Stage */

        if (Project.CurrentStage != ProjectStage.LO.Value)
        {
          return Result<Project>.Failure("Denied : Invalid previous stage" + Project.CurrentStage);
        }

        /* Promote the project to H2L*/


        Project.SPStart = request.SPDetails.SPStart;
        Project.SPDescription = request.SPDetails.SPDescription;
        Project.CurrentStage = ProjectStage.SP.Value;
        Project.Status = ProjectStatus.Active.Value;
        Project.SPEnabled = true;

        /* Prediction of Next Stage Start Date */
        var fetchPredictedDaysToAdd = await _context.AppVals.FirstOrDefaultAsync((v) => v.Key == "SPAnticipatedDays");

        double daysToAdd = 275; /* This is the default value, unless overridden by database */
        if (fetchPredictedDaysToAdd != null)
        {
          daysToAdd = Double.Parse(fetchPredictedDaysToAdd.Value);
        }

        Project.INDPredictedStart = Project.SPStart.AddDays(daysToAdd);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to promote project to SP");
        return Result<Project>.Success(Project);

      }

    }
  }
}