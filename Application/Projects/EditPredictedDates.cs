using System;
using System.Collections.Generic;
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
  public class EditPredictedDates
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

        var projectToEdit = await _context.Projects
        .Include(P => P.PrimaryOrg)
        .Include(p => p.SupportingOrgs)
        .FirstOrDefaultAsync
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

        /* Edit Priv */

        // get primary org id
        var primaryOrgId = projectToEdit.PrimaryOrg.Id;
        // get user's org id
        var userOrgId = await _userAccessor.GetUserOrgId();
        var isAdmin = await _userAccessor.isInRole("admin");
        var isProjectManager = await _userAccessor.isInRole("projectManager");
        var isInPrimaryGroup = primaryOrgId == userOrgId ? true : false;

        var secondaryOrgIds = new List<Guid>();
        foreach (var sorg in projectToEdit.SupportingOrgs)
        {
          secondaryOrgIds.Add(sorg.AppOrgId);
        }

        if (!(isInPrimaryGroup || secondaryOrgIds.Contains(userOrgId) || isAdmin || isProjectManager))
        {
          return Result<Project>.Failure("Denied : Not enough permissions to edit");
        }

        // Start Edit
        bool isChanged = false;

        if (projectToEdit.CurrentStage == ProjectStage.HA.Value)
        {
          if (request.project.H2LPredictedStart < DateTime.UtcNow)
          {
            return Result<Project>.Failure("Failed : Predicted Date needs to be in the future.");
          }
          projectToEdit.H2LPredictedStart = request.project.H2LPredictedStart;
          isChanged = true;
        }

        if (projectToEdit.CurrentStage == ProjectStage.H2L.Value)
        {
          if (request.project.LOPredictedStart < DateTime.UtcNow)
          {
            return Result<Project>.Failure("Failed : Predicted Date needs to be in the future.");
          }
          projectToEdit.LOPredictedStart = request.project.LOPredictedStart;
          isChanged = true;
        }

        if (projectToEdit.CurrentStage == ProjectStage.LO.Value)
        {
          if (request.project.SPPredictedStart < DateTime.UtcNow)
          {
            return Result<Project>.Failure("Failed : Predicted Date needs to be in the future.");
          }
          projectToEdit.SPPredictedStart = request.project.SPPredictedStart;
          isChanged = true;
        }
        if (projectToEdit.CurrentStage == ProjectStage.SP.Value)
        {
          if (request.project.INDPredictedStart < DateTime.UtcNow)
          {
            return Result<Project>.Failure("Failed : Predicted Date needs to be in the future.");
          }
          projectToEdit.INDPredictedStart = request.project.INDPredictedStart;
          isChanged = true;
        }
        if (projectToEdit.CurrentStage == ProjectStage.IND.Value)
        {
          if (request.project.ClinicalP1PredictedStart < DateTime.UtcNow)
          {
            return Result<Project>.Failure("Failed : Predicted Date needs to be in the future.");
          }
          projectToEdit.ClinicalP1PredictedStart = request.project.ClinicalP1PredictedStart;
          isChanged = true;
        }

        if (!isChanged)
        {
          return Result<Project>.Failure("Failed : No changes in dates.");
        }
        projectToEdit.LastModified = DateTime.UtcNow;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to edit project");
        return Result<Project>.Success(projectToEdit);

      }

    }
  }
}