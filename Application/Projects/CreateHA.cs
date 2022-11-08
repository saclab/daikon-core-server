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
  public class CreateHA
  {
    public class Command : IRequest<Result<Project>>
    {
      public ProjectCreateDTO NewProject { get; set; }
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

        var baseScreen = await _context.Screens.FirstOrDefaultAsync
            (s => s.Id == request.NewProject.ScreenId);

        /*chek if screen id is correct*/
        if (baseScreen == null)
        {
          return Result<Project>.Failure("Invalid Screen ID");
        }

        /* check if the project name is already taken */
        var checkIfProjectNameExists = await _context.Projects.FirstOrDefaultAsync
        (p => p.ProjectName == request.NewProject.ProjectName);
        if (checkIfProjectNameExists != null)
        {
          return Result<Project>.Failure("The project name is already in use. Please try with a different name");
        }

        /* Create the new project */
        Console.WriteLine("[Will try] to create new project");
        var newProject = new Project();
        var newProjectGuid = Guid.NewGuid();
        newProject.Id = newProjectGuid;
        newProject.ScreenId = baseScreen.Id;
        newProject.BaseScreen = baseScreen;
        newProject.ScreenName = baseScreen.ScreenName; 
        newProject.ProjectName = request.NewProject.ProjectName;
        newProject.TargetName = baseScreen.TargetName;
        newProject.TargetId = baseScreen.TargetId;

        if(baseScreen.TargetName == null){
          newProject.ProjectType = ProjectTypes.Phenotypic.Value;
        }
        else{
          newProject.ProjectType = ProjectTypes.TargetBased.Value;
        }


        Console.WriteLine("[Complete] new project");

        /*Verify the hits and add them to the project*/
        Console.WriteLine("[Will try] to create basehits");
        newProject.BaseHits = new List<ProjectBaseHits>();
        Console.WriteLine("[Initialized] base hits");
        foreach (var hit in request.NewProject.BaseHits)
        {
          /* Check if the hit is valid */
          var hitFromDb = await _context.Hits.FirstOrDefaultAsync(h => h.Id == hit.Id);
          if (hitFromDb != null && hitFromDb.ScreenId == hit.ScreenId)
          {
            var projectbaseHitToAdd = new ProjectBaseHits()
            {
              Id = Guid.NewGuid(),
              ProjectId = newProjectGuid,
              //BaseProject = newProject,
              HitId = hitFromDb.Id,
              BaseHit = hitFromDb,
            };

            newProject.BaseHits.Add(projectbaseHitToAdd);
            Console.WriteLine("[x/Will try] add base hit");
            _context.ProjectBaseHits.Add(projectbaseHitToAdd);
            Console.WriteLine("[x/ Added] basehit");
          }
        }

        /* verify the compound and set it as representation structure */
        var compoundFromDb = await _context.Compounds.FirstOrDefaultAsync
          (c => c.Id == request.NewProject.RepresentationStructure.Id);

        if (compoundFromDb != null)
        {
          Console.WriteLine("[Will try] to link compound (rep structure)");
          newProject.RepresentationStructureId = compoundFromDb.Id;
          newProject.RepresentationStructure = compoundFromDb;
          Console.WriteLine("[Complete] linking compound");
        }

        /* verify the primaryorg*/
        var primaryOrgFromDb = await _context.AppOrgs.FirstOrDefaultAsync
          (o => o.Id == request.NewProject.PrimaryOrg.Id);
        if (primaryOrgFromDb != null)
        {
          Console.WriteLine("[Will try] to link primary org");
          newProject.PrimaryOrgId = primaryOrgFromDb.Id;
          newProject.PrimaryOrg = primaryOrgFromDb;
          Console.WriteLine("[Complete] link primary org");
        }

        /* verify the supporting orgs */
        newProject.SupportingOrgs = new List<ProjectSupportingOrg>();
        foreach (var supportingOrg in request.NewProject.SupportingOrgs)
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

        // HA Details
        newProject.HAStart = request.NewProject.HAStart;
        newProject.HADescription = request.NewProject.HADescription;
        newProject.CurrentStage = ProjectStage.HA.Value;
        newProject.Status = ProjectStatus.Active.Value;
        newProject.HAEnabled = true;
        newProject.LastModified = request.NewProject.HAStart;

        /* Prediction of Next Stage Start Date */
        var fetchPredictedDaysToAdd = await _context.AppVals.FirstOrDefaultAsync((v) => v.Key == "HAAnticipatedDays");
        
        double daysToAdd = 350; /* This is the default value, unless overridden by database */
        if (fetchPredictedDaysToAdd != null)
        {
          daysToAdd = Double.Parse(fetchPredictedDaysToAdd.Value);
        }
       
        newProject.H2LPredictedStart = newProject.HAStart.AddDays(daysToAdd);
        
        _context.Projects.Add(newProject);
        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        /* To Strat of the compond evolution timeline, add the primary hit as a starting point */
        var projectCompoundEvolution = new CompoundEvolutionDTO
        {
          Smile = compoundFromDb.Smile,
          MolWeight = compoundFromDb.MolWeight,
          MolArea = compoundFromDb.MolArea,
          ProjectId = newProjectGuid,
          Notes = "Initial HA Compound",
          MIC = request.NewProject.BaseHits.Find((h) => h.CompoundId == compoundFromDb.Id).MIC,
          IC50 = request.NewProject.BaseHits.Find((h) => h.CompoundId == compoundFromDb.Id).IC50,
          CreatedAt = DateTime.UtcNow,
          CreatedBy = _userAccessor.GetUsername()
        };
        await _mediator.Send(new Application.Projects.CompoundEvolution.Add.Command { NewProjectCompoundEvolution = projectCompoundEvolution });

        if (!success) return Result<Project>.Failure("Failed to create H2L");
        return Result<Project>.Success(newProject);

      }

    }
  }
}