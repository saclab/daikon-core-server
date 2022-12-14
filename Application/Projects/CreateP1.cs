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
  public class CreateP1
  {
    public class Command : IRequest<Result<Project>>
    {
      public P1DTO P1Details { get; set; }
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
            (p => p.Id == request.P1Details.Id);

        /*chek if project id is correct*/
        if (Project == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }

        if (Project.Status == ProjectStatus.Terminated.Value)
        {
          return Result<Project>.Failure("Denied : Cannot modify a terminated project");
        }


        /* check if the project is in SP Stage */

        if (Project.CurrentStage != ProjectStage.IND.Value)
        {
          return Result<Project>.Failure("Denied : Invalid previous stage" + Project.CurrentStage);
        }

        /* Promote the project to IND*/


        Project.ClinicalP1Start = request.P1Details.P1Start;
        Project.ClinicalP1Description = request.P1Details.P1Description;
        Project.CurrentStage = ProjectStage.P1.Value;
        Project.Status = ProjectStatus.Active.Value;
        Project.ClinicalP1Enabled = true;
        Project.LastModified = request.P1Details.P1Start;

        /* Prediction of Next Stage Start Date */
        // var fetchPredictedDaysToAdd = await _context.AppVals.FirstOrDefaultAsync((v) => v.Key == "INDAnticipatedDays");

        // double daysToAdd = 275; /* This is the default value, unless overridden by database */
        // if (fetchPredictedDaysToAdd != null)
        // {
        //   daysToAdd = Double.Parse(fetchPredictedDaysToAdd.Value);
        // }

        // Project.ClinicalP1PredictedStart = Project.INDStart.AddDays(daysToAdd);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to promote project to P1");
        return Result<Project>.Success(Project);

      }

    }
  }
}