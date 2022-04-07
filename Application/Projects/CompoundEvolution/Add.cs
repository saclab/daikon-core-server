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
  public class Add
  {
    public class Command : IRequest<Result<ProjectCompoundEvolution>>
    {
      public CompoundEvolutionAddDTO NewProjectCompoundEvolution { get; set; }
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

        var baseProject = await _context.Projects.FirstOrDefaultAsync
            (p => p.Id == request.NewProjectCompoundEvolution.ProjectId);

        /*chek if screen id is correct*/
        if (baseProject == null)
        {
          return Result<ProjectCompoundEvolution>.Failure("Invalid Project ID" + request.NewProjectCompoundEvolution.ProjectId);
        }

        if (baseProject.Status == ProjectStatus.Terminated.Value)
        {
          return Result<ProjectCompoundEvolution>.Failure("Denied : Cannot modify a terminated project");
        }


        
        Console.WriteLine("[Project] Found");
        
        /* check if the compound smile exists */
        var compound = await _context.Compounds.FirstOrDefaultAsync
        (c => c.Smile == request.NewProjectCompoundEvolution.Smile);

        

        if (compound == null)
        {
          Console.WriteLine("[Compound] was null, creating");
          compound = new Compound();
          compound.Smile = request.NewProjectCompoundEvolution.Smile;
          compound.MolArea = request.NewProjectCompoundEvolution.MolArea;
          compound.MolWeight = request.NewProjectCompoundEvolution.MolWeight;
          compound.Id = Guid.NewGuid();
          _context.Compounds.Add(compound);
        }

        Console.WriteLine("[Compound] is now");
        Console.WriteLine(compound.Id); 


        /* Create the new ProjectCompoundEvolution */
        var newProjectCompoundEvolution = new ProjectCompoundEvolution();
        var newProjectCompoundEvolutionGuid = Guid.NewGuid();

        newProjectCompoundEvolution.Id = newProjectCompoundEvolutionGuid;
        newProjectCompoundEvolution.ProjectId = baseProject.Id;
        
        newProjectCompoundEvolution.CompoundId = compound.Id;
        newProjectCompoundEvolution.AddedOnDate = DateTime.UtcNow;
        newProjectCompoundEvolution.AddedOnStage = baseProject.CurrentStage;
        newProjectCompoundEvolution.Notes = request.NewProjectCompoundEvolution.Notes;
        newProjectCompoundEvolution.MIC = request.NewProjectCompoundEvolution.MIC;
        newProjectCompoundEvolution.IC50 = request.NewProjectCompoundEvolution.IC50;

        newProjectCompoundEvolution.CreatedAt = DateTime.UtcNow;
        newProjectCompoundEvolution.CreatedBy = _userAccessor.GetUsername();

        _context.ProjectCompoundEvolutions.Add(newProjectCompoundEvolution);
        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;


        if (!success) return Result<ProjectCompoundEvolution>.Failure("Failed to create compound evolution");
        return Result<ProjectCompoundEvolution>.Success(newProjectCompoundEvolution);

      }

    }
  }
}