using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Projects.DTOs;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Projects
{
  public class EditSupportingOrgs
  {
    public class Command : IRequest<Result<Project>>
    {
      public SupportingOrgDTO supportingOrgDTO { get; set; }
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
      private readonly IUserAccessor _userAccessor;

      public Handler(DataContext context, IUserAccessor userAccessor)
      {
        _context = context;
        _userAccessor = userAccessor;
      }
      public async Task<Result<Project>> Handle(Command request, CancellationToken cancellationToken)
      {

        var projectToEdit = await _context.Projects
        .Include(P => P.PrimaryOrg)
        .Include(p => p.SupportingOrgs)
        .FirstOrDefaultAsync
            (p => p.Id == request.supportingOrgDTO.ProjectId);

        /* chek if project id is correct*/
        if (projectToEdit == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }

        /* check if the project is in Terminated State */

        if (projectToEdit.Status == ProjectStatus.Terminated.Value)
        {
          return Result<Project>.Failure("Denied : Cannot modify a terminated project");
        }

        var originalSupportingOrgs = new List<Guid>();
        var newSupportingOrgs = new List<Guid>();
        originalSupportingOrgs = projectToEdit.SupportingOrgs.Select((o => o.AppOrgId)).ToList();

        /* validate all suppoting group ids*/
        newSupportingOrgs = new List<Guid>();
        foreach (var sgid in request.supportingOrgDTO.ModifiedSupportingOrgs)
        {
          var sg = await _context.AppOrgs.FirstOrDefaultAsync(o => o.Id == sgid);
          if (sg != null)
          {
            newSupportingOrgs.Add(sg.Id);
          }
        }

        // get primary org id
        var primaryOrgId = projectToEdit.PrimaryOrg.Id;
        // get user's org id
        var userOrgId = await _userAccessor.GetUserOrgId();

        // to remove
        var removeSupportingOrgs = originalSupportingOrgs.Except(newSupportingOrgs).ToList();
        // prevent removal of primary group in the supporting group list
        removeSupportingOrgs.Remove(primaryOrgId);

        // to add
        var addSupportingOrgs = newSupportingOrgs.Except(originalSupportingOrgs).ToList();

        // user permissions
        var isAdmin = await _userAccessor.isInRole("admin");
        var isProjectManager = await _userAccessor.isInRole("projectManager");
        var isInPrimaryGroup = primaryOrgId == userOrgId ? true : false;

        // check if the user belongs to primary oirganization or is a pm or admin
        // then proceed with all additional or removal
        if (isAdmin || isProjectManager || isInPrimaryGroup)
        {
          // add
          foreach (var supportingOrgId in addSupportingOrgs)
          {
            var supportingOrgToAdd = new ProjectSupportingOrg()
            {
              Id = Guid.NewGuid(),
              ProjectId = projectToEdit.Id,
              AppOrgId = supportingOrgId
            };
            projectToEdit.SupportingOrgs.Add(supportingOrgToAdd);
            _context.ProjectSupportingOrgs.Add(supportingOrgToAdd);
          }
          //remove
          foreach (var supportingOrgId in removeSupportingOrgs)
          {
            var supportingOrgToremove = await
                _context.ProjectSupportingOrgs.FirstOrDefaultAsync(o =>
                (o.ProjectId == projectToEdit.Id)
                 && (o.AppOrgId == supportingOrgId));

            projectToEdit.SupportingOrgs.Remove(supportingOrgToremove);
            _context.ProjectSupportingOrgs.Remove(supportingOrgToremove);
          }
        }
        else
        {
          // if not, the user is allowed to add or remove his org only

          if (originalSupportingOrgs.Contains(userOrgId) && !newSupportingOrgs.Contains(userOrgId))
          {
            // Remove
            Console.WriteLine("Remove " + userOrgId);
            var supportingOrgToremove = await
                _context.ProjectSupportingOrgs.FirstOrDefaultAsync(o =>
                (o.ProjectId == projectToEdit.Id)
                 && (o.AppOrgId == userOrgId));

            projectToEdit.SupportingOrgs.Remove(supportingOrgToremove);
            _context.ProjectSupportingOrgs.Remove(supportingOrgToremove);

          }

          if (!originalSupportingOrgs.Contains(userOrgId) && newSupportingOrgs.Contains(userOrgId))
          {
            // Add
            Console.WriteLine("Add " + userOrgId);
            var supportingOrgToAdd = new ProjectSupportingOrg()
            {
              Id = Guid.NewGuid(),
              ProjectId = projectToEdit.Id,
              AppOrgId = userOrgId
            };
            projectToEdit.SupportingOrgs.Add(supportingOrgToAdd);
            _context.ProjectSupportingOrgs.Add(supportingOrgToAdd);
          }
        }


        projectToEdit.LastModified = DateTime.UtcNow;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to edit project");
        return Result<Project>.Success(projectToEdit);

      }

    }
  }
}