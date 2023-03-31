using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Application.Projects.CompoundEvolution
{
  public class Edit
  {
    public class Command : IRequest<Result<ProjectCompoundEvolution>>
    {
      public CompoundEvolutionDTO EditedProjectCompoundEvolution { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<ProjectCompoundEvolution>>
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
      public async Task<Result<ProjectCompoundEvolution>> Handle(Command request, CancellationToken cancellationToken)
      {

        /* check if compound evolution Id is correct */

        var existingCompoundEvolution = await _context.ProjectCompoundEvolutions.FirstOrDefaultAsync
          (p => p.Id == request.EditedProjectCompoundEvolution.Id);

        if (existingCompoundEvolution == null)
        {
          return Result<ProjectCompoundEvolution>.Failure("Invalid Compound Evolution ID" + request.EditedProjectCompoundEvolution.Id);
        }

        var baseProject = await _context.Projects.FirstOrDefaultAsync
            (p => p.Id == request.EditedProjectCompoundEvolution.ProjectId);

        /* check if screen id is correct */
        if (baseProject == null)
        {
          return Result<ProjectCompoundEvolution>.Failure("Invalid Project ID" + request.EditedProjectCompoundEvolution.ProjectId);
        }

        if (baseProject.Status == ProjectStatus.Terminated.Value)
        {
          return Result<ProjectCompoundEvolution>.Failure("Denied : Cannot modify a terminated project");
        }

        var compound = await _context.Compounds.FirstOrDefaultAsync
        (c => c.Id == request.EditedProjectCompoundEvolution.CompoundId);

        if (compound == null)
        {
          return Result<ProjectCompoundEvolution>.Failure("Invalid Compound ID ");
        }

        // check if stage has changed
        if (existingCompoundEvolution.AddedOnStage != request.EditedProjectCompoundEvolution.AddedOnStage)
        {
          try
          {
            var commons = new Application.Projects.Common();
            existingCompoundEvolution.AddedOnStage = commons.StageGen(request.EditedProjectCompoundEvolution.AddedOnStage);
          }
          catch (ArgumentException e)
          {
            return Result<ProjectCompoundEvolution>.Failure("Invalid Stage " + e);
          }
        }

        // Added date change
        existingCompoundEvolution.AddedOnDate = request.EditedProjectCompoundEvolution.AddedOnDate;

        // Other params change
        existingCompoundEvolution.Notes = request.EditedProjectCompoundEvolution.Notes;
        existingCompoundEvolution.MIC = request.EditedProjectCompoundEvolution.MIC;
        existingCompoundEvolution.IC50 = request.EditedProjectCompoundEvolution.IC50;

        /* Allow modifying compound MolArea and MolWeight Only  */
        compound.MolArea = request.EditedProjectCompoundEvolution.MolArea;
        compound.MolWeight = request.EditedProjectCompoundEvolution.MolWeight;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;


        if (!success) return Result<ProjectCompoundEvolution>.Failure("Failed to modify compound evolution");
        return Result<ProjectCompoundEvolution>.Success(existingCompoundEvolution);
      }

    }
  }
}