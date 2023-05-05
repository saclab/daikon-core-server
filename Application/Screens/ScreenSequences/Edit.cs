using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens.ScreenSequences
{
  public class Edit
  {
    public class Command : IRequest<Result<ScreenSequence>>
    {
      public ScreenSequence ScreenSequence { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<ScreenSequence>>
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
      public async Task<Result<ScreenSequence>> Handle(Command request, CancellationToken cancellationToken)
      {

        /* check if the screen exists */
        var screenSequence = await _context.ScreenSequences.FirstOrDefaultAsync(s => s.Id == request.ScreenSequence.Id);

        if (screenSequence == null)
        {
          return Result<ScreenSequence>.Failure("Invalid Screen Sequence ID");
        }

        /* Allow edits if 
          1. screenSequence is owned by the user
          2. Base Screen is owned by the user's org
          3. User is admin
        */

        var baseScreen = await _context.Screens.FirstOrDefaultAsync(s => s.Id == screenSequence.ScreenId);
        if (baseScreen == null)
        {
          return Result<ScreenSequence>.Failure("Invalid Screen ID");
        }

        var userOrgId = await _userAccessor.GetUserOrgId();
        if (userOrgId == Guid.Empty)
        {
          return Result<ScreenSequence>.Failure("Fail: User does not belong to an organization");
        }

        bool allowedToEdit = false;

        if (await _userAccessor.isInRole("admin"))
        {
          allowedToEdit = true;
        }

        else if (screenSequence.CreatedBy == _userAccessor.GetUsername())
        {
          allowedToEdit = true;
        }

        else if (baseScreen.CreatedBy == _userAccessor.GetUsername())
        {
          allowedToEdit = true;
        }
        else if (userOrgId == baseScreen.OrgId)
        {
          allowedToEdit = true;
        }

        if (!allowedToEdit)
        {
          return Result<ScreenSequence>.Failure("You do not have permission to edit this screen sequence");
        }

        /* Start editing the screen sequence */

        screenSequence.Method = request.ScreenSequence.Method;
        screenSequence.Protocol = request.ScreenSequence.Protocol;
        screenSequence.Library = request.ScreenSequence.Library;
        screenSequence.Scientist = request.ScreenSequence.Scientist;
        screenSequence.StartDate = request.ScreenSequence.StartDate;
        screenSequence.EndDate = request.ScreenSequence.EndDate;
        screenSequence.UnverifiedHitCount = request.ScreenSequence.UnverifiedHitCount;
        screenSequence.NoOfCompoundsScreened = request.ScreenSequence.NoOfCompoundsScreened;
        screenSequence.Concentration = request.ScreenSequence.Concentration;
        screenSequence.ConcentrationUnit = request.ScreenSequence.ConcentrationUnit;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<ScreenSequence>.Failure("Failed to edit Screen Sequence");
        return Result<ScreenSequence>.Success(screenSequence);

      }


    }
  }
}