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
  public class SetPriorityProbability
  {
    public class Command : IRequest<Result<Project>>
    {
      public ProjectPriorityProbabilityDTO projectPriorityProbabilityDTO { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Project>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _mapper = mapper;
        _context = context;
        _userAccessor = userAccessor;

      }
      public async Task<Result<Project>> Handle(Command request, CancellationToken cancellationToken)
      {
        var project = await _context.Projects
        .FirstOrDefaultAsync(p => p.Id == request.projectPriorityProbabilityDTO.Id);

        if (project == null) return Result<Project>.Failure("Invalid Project Id");

        project.TeamProbability = request.projectPriorityProbabilityDTO.TeamProbability;
        project.TeamProbabilityDescription = request.projectPriorityProbabilityDTO.TeamProbabilityDescription;
        project.TeamPriority = request.projectPriorityProbabilityDTO.TeamPriority;
        project.TeamPriorityDescription = request.projectPriorityProbabilityDTO.TeamPriorityDescription;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Project>.Failure("Failed to modify project");
        return Result<Project>.Success(project);
      }

    }

  }
}