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
  public class Terminate
  {
    public class Command : IRequest<Result<Project>>
    {
      public ProjectTerminateDTO project { get; set; }
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

        var projectToTerminate = await _context.Projects.FirstOrDefaultAsync
            (p => p.Id == request.project.Id);

        /*chek if project id is correct*/
        if (projectToTerminate == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }

        /* check if the project is in Terminated State */

        if (projectToTerminate.Status == ProjectStatus.Terminated.Value)
        {
          return Result<Project>.Failure("Denied : Cannot modify a terminated project");
        }

        if (projectToTerminate.ProjectName != request.project.ProjectName)
        {
          return Result<Project>.Failure("Failed : Name mismatch");
        }

        /* Promote the project to H2L*/

        projectToTerminate.Status = ProjectStatus.Terminated.Value;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to terminate project");
        return Result<Project>.Success(projectToTerminate);

      }

    }
  }
}