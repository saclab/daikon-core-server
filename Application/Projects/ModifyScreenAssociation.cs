using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Screens.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

/*
    This would replace the screen linked with projects.
    I/P - screenIDtoModify -> Find all projects associated with the screenid
    I/P - newScreenId -> Replace with this screen

    Example use :
    Used while merging screens in the Screening sections. Once two screens are merged,
    the project data of the merged screen needs to be transfered to the new screen.
*/

namespace Application.Projects
{
  public class ModifyScreenAssociation
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Guid screenIdToModify { get; set; }
      public Guid newScreenId { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
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
      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {

        /* Fetch all the projects associated with the screenid that is being changed */
        var projects = await _context.Projects.Where(
            p => p.ScreenId == request.screenIdToModify
        ).ToListAsync();

        /* Loop through all the projects and replace */
        foreach(var project in projects)
        {
            project.ScreenId = request.newScreenId;
        }

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Unit>.Failure("Failed to edit project");
        return Result<Unit>.Success(Unit.Value);

      }

    }
  }


}