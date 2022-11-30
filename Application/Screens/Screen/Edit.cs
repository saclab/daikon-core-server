using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens
{
  public class Edit
  {
    public class Command : IRequest<Result<Screen>>
    {
      public Screen ModifiedScreen { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Screen>>
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
      public async Task<Result<Screen>> Handle(Command request, CancellationToken cancellationToken)
      {
        
        var screen = await _context.Screens
        .Include(h => h.Org)
        .FirstOrDefaultAsync(s => s.Id == request.ModifiedScreen.Id);

        /*chek if screen id is correct*/
        if (screen == null)
        {
          return Result<Screen>.Failure("Invalid Screen ID");
        }

        var org = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Id == request.ModifiedScreen.Org.Id);
        if (org == null)
        {
          return Result<Screen>.Failure("Bad org id");
        }

        screen.CreatedAt = request.ModifiedScreen.CreatedAt;
        screen.OrgId = org.Id;
        screen.Method = request.ModifiedScreen.Method;
        screen.Notes = request.ModifiedScreen.Notes;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Screen>.Failure("Failed to modify screen");
        return Result<Screen>.Success(screen);

      }


    }
  }
}