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

namespace Application.Projects
{
  public class CreateUnlinkedProject
  {
    public class Command : IRequest<Result<Project>>
    {
      public UnlinkedProjectCreateDTO NewProjectForm { get; set; }
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
      private IMediator _mediator;

      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor, IMediator mediator)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
        _mediator = mediator;
      }
      public async Task<Result<Project>> Handle(Command request, CancellationToken cancellationToken)
      {



        /* check if the project name is already taken */
        var checkIfProjectNameExists = await _context.Projects.FirstOrDefaultAsync
        (p => p.ProjectName == request.NewProjectForm.ProjectName);
        if (checkIfProjectNameExists != null)
        {
          return Result<Project>.Failure("The project name is already in use. Please try with a different name");
        }

        /* Create the new project */
        Console.WriteLine("[Will try] to create new project");
        var newProject = new Project();
        var newProjectGuid = Guid.NewGuid();
        newProject.Id = newProjectGuid;
        newProject.ProjectName = request.NewProjectForm.ProjectName;



        Console.WriteLine("[Complete] new project");



        /* verify the compound and set it as representation structure */
        var compoundFromDb = await _context.Compounds.FirstOrDefaultAsync
          (c => c.Smile == request.NewProjectForm.RepresentationStructureSMILE);

        if (compoundFromDb != null)
        {
          Console.WriteLine("[Will try] to link compound (rep structure)");
          newProject.RepresentationStructureId = compoundFromDb.Id;
          newProject.RepresentationStructure = compoundFromDb;
          Console.WriteLine("[Complete] linking compound");
        }
        else
        {
          compoundFromDb = new Compound()
          {
            Id = Guid.NewGuid(),
            Smile = request.NewProjectForm.RepresentationStructureSMILE,
            ExternalCompoundIds = request.NewProjectForm.RepresentationStructureExternalCompoundIds,
            MolWeight = request.NewProjectForm.MolWeight,
            MolArea = request.NewProjectForm.MolArea
          };

          _context.Compounds.Add(compoundFromDb);
        }

        /* verify the primaryorg*/
        var primaryOrgFromDb = await _context.AppOrgs.FirstOrDefaultAsync
          (o => o.Id == request.NewProjectForm.PrimaryOrg.Id);
        if (primaryOrgFromDb != null)
        {
          Console.WriteLine("[Will try] to link primary org");
          newProject.PrimaryOrgId = primaryOrgFromDb.Id;
          newProject.PrimaryOrg = primaryOrgFromDb;
          Console.WriteLine("[Complete] link primary org");
        }

        /* verify the supporting orgs */
        newProject.SupportingOrgs = new List<ProjectSupportingOrg>();
        foreach (var supportingOrg in request.NewProjectForm.SupportingOrgs)
        {
          var supportingOrgFromDb = await _context.AppOrgs.FirstOrDefaultAsync
          (o => o.Id == supportingOrg.Id);
          if (supportingOrg != null)
          {
            var supportingOrgToAdd = new ProjectSupportingOrg()
            {
              Id = Guid.NewGuid(),
              ProjectId = newProjectGuid,
              //BaseProject = newProject,
              AppOrgId = supportingOrgFromDb.Id,
              AppOrg = supportingOrgFromDb
            };
            Console.WriteLine("[x/Will try] to link secondary org");
            newProject.SupportingOrgs.Add(supportingOrgToAdd);
            _context.ProjectSupportingOrgs.Add(supportingOrgToAdd);
            Console.WriteLine("[x/ Complete] to link secondary org");
          }
        }

        // FHA Details
        newProject.FHAStart = request.NewProjectForm.FHAStart;
        newProject.FHADescription = request.NewProjectForm.FHADescription;
        newProject.CurrentStage = ProjectStage.FHA.Value;
        newProject.Status = ProjectStatus.Active.Value;
        newProject.FHAEnabled = true;
        newProject.LastModified = DateTime.UtcNow;

        /* Prediction of Next Stage Start Date */
        var fetchPredictedDaysToAdd = await _context.AppVals.FirstOrDefaultAsync((v) => v.Key == "FHAAnticipatedDays");

        double daysToAdd = 350; /* This is the default value, unless overridden by database */
        if (fetchPredictedDaysToAdd != null)
        {
          daysToAdd = Double.Parse(fetchPredictedDaysToAdd.Value);
        }

        newProject.H2LPredictedStart = newProject.FHAStart.AddDays(daysToAdd);

        _context.Projects.Add(newProject);
        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        /* To Strat of the compond evolution timeline, add the primary hit as a starting point */
        var projectCompoundEvolution = new CompoundEvolutionAddDTO
        {
          Smile = compoundFromDb.Smile,
          MolWeight = request.NewProjectForm.MolWeight,
          MolArea = request.NewProjectForm.MolArea,
          ProjectId = newProjectGuid,
          Notes = "Initial FHA Compound",
          MIC = request.NewProjectForm.MIC,
          IC50 = request.NewProjectForm.IC50,
          CreatedAt = DateTime.UtcNow,
          CreatedBy = _userAccessor.GetUsername()
        };
        await _mediator.Send(new Application.Projects.CompoundEvolution.Add.Command { NewProjectCompoundEvolution = projectCompoundEvolution });

        if (!success) return Result<Project>.Failure("Failed to create project");
        return Result<Project>.Success(newProject);

      }

    }
  }
}