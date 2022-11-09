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
  public class Edit
  {
    public class Command : IRequest<Result<Project>>
    {
      public ProjectEditDTO project { get; set; }
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

        var projectToEdit = await _context.Projects.FirstOrDefaultAsync
            (p => p.Id == request.project.Id);

        /*chek if project id is correct*/
        if (projectToEdit == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }

        /* check if the project is in Terminated State */

        if (projectToEdit.Status == ProjectStatus.Terminated.Value)
        {
          return Result<Project>.Failure("Denied : Cannot modify a terminated project");
        }

        /* Promote the project to H2L*/

        projectToEdit.Priority = request.project.Priority;
        projectToEdit.PriorityDescription = request.project.PriorityDescription;
        projectToEdit.Probability = request.project.Probability;
        projectToEdit.ProbabilityDescription = request.project.ProbabilityDescription;

        projectToEdit.TeamPriority = request.project.TeamPriority;
        projectToEdit.TeamPriorityDescription = request.project.TeamPriorityDescription;
        projectToEdit.TeamProbability = request.project.TeamProbability;
        projectToEdit.TeamProbabilityDescription = request.project.TeamProbabilityDescription;

        projectToEdit.HAStart = request.project.HAStart;
        projectToEdit.HAPredictedStart = request.project.HAPredictedStart;
        projectToEdit.HADescription = request.project.HADescription;

        projectToEdit.H2LStart = request.project.H2LStart;
        projectToEdit.H2LPredictedStart = request.project.H2LPredictedStart;
        projectToEdit.H2LDescription = request.project.H2LDescription;

        projectToEdit.LOStart = request.project.LOStart;
        projectToEdit.LOPredictedStart = request.project.LOPredictedStart;
        projectToEdit.LODescription = request.project.LODescription;

        projectToEdit.SPStart = request.project.SPStart;
        projectToEdit.SPPredictedStart = request.project.SPPredictedStart;
        projectToEdit.SPDescription = request.project.SPDescription;

        projectToEdit.PCDDate = request.project.PCDDate;
        projectToEdit.PCDDescription = request.project.PCDDescription;

        projectToEdit.INDStart = request.project.INDStart;
        projectToEdit.INDPredictedStart = request.project.INDPredictedStart;
        projectToEdit.INDDescription = request.project.INDDescription;

        projectToEdit.ClinicalP1Start = request.project.ClinicalP1Start;
        projectToEdit.ClinicalP1PredictedStart = request.project.ClinicalP1PredictedStart;
        projectToEdit.ClinicalP1Description = request.project.ClinicalP1Description;

        projectToEdit.LastModified = DateTime.UtcNow;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to edit project");
        return Result<Project>.Success(projectToEdit);

      }

    }
  }
}