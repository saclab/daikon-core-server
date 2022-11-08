using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Votes.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Votes.Imports
{
  public class ImportExisting
  {

    /*

    The purpose of this class is to import legacy votes that are maintained elsewhere.

    */
    public class Command : IRequest<Result<Unit>>
    {
      public ImportVoteDTO importVote { get; set; }
    }
    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.UserVote).SetValidator(new VoteValidator());
    //   }

    // }

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

        // Fetch Vote
        var existingVote = _context.Votes.FirstOrDefault(v => v.Id == request.importVote.Id);
        if (existingVote == null)
        {
          return Result<Unit>.Failure("Invaild voting Id");
        }

        /*
            Do not proceed if votes are't 0. It means entity has been voted using the app.
        */

        if (existingVote.Positive != 0 || existingVote.Negative != 0 || existingVote.Neutral != 0)
        {
          return Result<Unit>.Failure("Voting state is invalid / votes are already registered");
        }

        existingVote.Positive = request.importVote.Positive;
        existingVote.Negative = request.importVote.Negative;
        existingVote.Neutral = request.importVote.Neutral;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success)
        {
          return Result<Unit>.Failure("Internal App error");
        }

        return Result<Unit>.Success(Unit.Value);


      }
    }

  }
}