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
  public class CreateLO
  {
    public class Command : IRequest<Result<Project>>
    {
      public LODTO LODetails { get; set; }
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
            (p => p.Id == request.LODetails.Id);

        /*chek if project id is correct*/
        if (Project == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }

        if (Project.Status == ProjectStatus.Terminated.Value)
        {
          return Result<Project>.Failure("Denied : Cannot modify a terminated project");
        }


        /* check if the project is in HA Stage */

        if (Project.CurrentStage != ProjectStage.H2L.Value)
        {
          return Result<Project>.Failure("Denied : Invalid previous stage " + Project.CurrentStage);
        }

        /* Promote the project to H2L*/


        Project.LOStart = request.LODetails.LOStart;
        Project.LODescription = request.LODetails.LODescription;
        Project.CurrentStage = ProjectStage.LO.Value;
        Project.Status = ProjectStatus.Active.Value;
        Project.LOEnabled = true;
        Project.LastModified = request.LODetails.LOStart;

        /* Prediction of Next Stage Start Date */
        var fetchPredictedDaysToAdd = await _context.AppVals.FirstOrDefaultAsync((v) => v.Key == "LOAnticipatedDays");

        double daysToAdd = 585; /* This is the default value, unless overridden by database */
        if (fetchPredictedDaysToAdd != null)
        {
          daysToAdd = Double.Parse(fetchPredictedDaysToAdd.Value);
        }

        Project.SPPredictedStart = Project.LOStart.AddDays(daysToAdd);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to promote project to LO");
        return Result<Project>.Success(Project);

      }

    }
  }
}