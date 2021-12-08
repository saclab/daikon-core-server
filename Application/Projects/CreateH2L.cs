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
  public class CreateH2L
  {
    public class Command : IRequest<Result<Project>>
    {
      public H2LDTO H2LDetails { get; set; }
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
            (p => p.Id == request.H2LDetails.Id);

        /*chek if project id is correct*/
        if (Project == null)
        {
          return Result<Project>.Failure("Invalid Project ID");
        }

        /* check if the project is in FHA Stage */

        if (Project.CurrentStage != ProjectStage.FHA.Value)
        {
          return Result<Project>.Failure("Denied : Invalid previous stage");
        }

        /* Promote the project to H2L*/


        Project.H2LStart = request.H2LDetails.H2LStart;
        Project.H2LDescription = request.H2LDetails.H2LDescription;
        Project.CurrentStage = ProjectStage.H2L.Value;
        Project.Status = ProjectStatus.Active.Value;
        Project.H2LEnabled = true;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to create screen");
        return Result<Project>.Success(Project);

      }

    }
  }
}