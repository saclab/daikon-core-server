using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Projects;
using Application.Screens.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens.Merge
{
  public class ScreenMerge
  {
    public class Command : IRequest<Result<Unit>>
    {
      public ScreenMergeIdDTO ScreenMergeIdDTO { get; set; }

    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Unit>>
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
      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Quick validation, if screen id's are same reject.
        if (request.ScreenMergeIdDTO.FirstScreenId == request.ScreenMergeIdDTO.MergeScreenId)
        {
          return Result<Unit>.Failure("Cannot Merge with itself.");
        }

        // Find the screens
        var FirstScreen = await _context.Screens
        .Include(h => h.ValidatedHits)
        .Include(h => h.ScreenSequences)
        .FirstOrDefaultAsync(s => s.Id == request.ScreenMergeIdDTO.FirstScreenId);

        if (FirstScreen == null)
        {
          return Result<Unit>.Failure("Invalid Initial Screen ID");
        }

        var MergeScreen = await _context.Screens
        .Include(h => h.ValidatedHits)
        .Include(h => h.ScreenSequences)
        .FirstOrDefaultAsync(s => s.Id == request.ScreenMergeIdDTO.MergeScreenId);

        if (MergeScreen == null)
        {
          return Result<Unit>.Failure("Invalid Merge Screen ID");
        }

        /* Restrictions
            1. Must belong to Same ORG
            2. Must have same screening method
        */
        if (FirstScreen.OrgId != MergeScreen.OrgId)
        {
          return Result<Unit>.Failure("Cannot Merge Screens From Different Orgs");
        }
        if (FirstScreen.Method != MergeScreen.Method)
        {
          return Result<Unit>.Failure("Cannot Merge Screens Having Different Screening Methods");
        }

        /*
            Screen Sequences Switch Over
            Loop through the screen sequences and modify their ScreenID, set to FirstScreenID
        */
        foreach (var screenSequence in MergeScreen.ScreenSequences)
        {
          screenSequence.ScreenId = FirstScreen.Id;
        }

        /*
            Validated Hits Switch Over
            Loop through the validated hits and modify their ScreenID, set to FirstScreenID
        */
        foreach (var validateHit in MergeScreen.ValidatedHits)
        {
          validateHit.ScreenId = FirstScreen.Id;
        }

        /*
            Transfer projects belonging to the screen
        */

        var pRes = await _mediator.Send(new ModifyScreenAssociation.Command
        {
          screenIdToModify = MergeScreen.Id,
          newScreenId = FirstScreen.Id
        });

        if (!pRes.IsSuccess)
        {
          return Result<Unit>.Failure("Failed changing project data.");
        }

        /* Delete the screen */

        _context.Remove(MergeScreen);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Unit>.Failure("Failed Merging Screen");

        return Result<Unit>.Success(Unit.Value);

      }


    }
  }

}
