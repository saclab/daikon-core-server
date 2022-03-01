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

namespace Application.Votes
{
  public class EnableVoting
  {
    public class Command : IRequest<Result<Unit>>
    {
      public List<Guid> VoteIds { get; set; }
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

        var success = true;

        foreach (var voteId in request.VoteIds)
        {
          var vote = await _context.Votes.FirstOrDefaultAsync(v => v.Id == voteId);
          if (vote == null) continue;
          if (!vote.IsVotingAllowed)
          {
            vote.IsVotingAllowed = true;
            success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0 && success;
          }
        }

        if (success)
        {
          return Result<Unit>.Success(Unit.Value);
        }

        return Result<Unit>.Failure("App Error, Failed to save.");

      }
    }

  }
}