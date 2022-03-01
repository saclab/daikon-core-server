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
  public class Vote
  {
    public class Command : IRequest<Result<VoteDTO>>
    {
      public RegisterVoteDTO UserVote { get; set; }
    }
    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.UserVote).SetValidator(new VoteValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<VoteDTO>>
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
      public async Task<Result<VoteDTO>> Handle(Command request, CancellationToken cancellationToken)
      {

        // Fetch Vote

        var vote = await _context.Votes.FirstOrDefaultAsync(v => v.Id == request.UserVote.VoteId);
        if (vote == null) return Result<VoteDTO>.Failure("App Error, Voting data does not exists.");

        // Check if voting is allowed
        if (!vote.IsVotingAllowed) return Result<VoteDTO>.Failure("Voting is not allowed for the object");

        // Check if user has already voted
        var prevVote = await _context.Voters.FirstOrDefaultAsync(v =>
            (v.VoteId == vote.Id) && (v.VoterEmail == _userAccessor.GetUsername()));
        if (prevVote != null) return Result<VoteDTO>.Failure("You have already voted");

        // Register vote
        Guid gid = Guid.NewGuid();
        var votedAt = DateTime.UtcNow;
        var voteToRegister = new Voter
        {
          Id = gid,
          VoteId = vote.Id,
          VoterEmail = _userAccessor.GetUsername(),
          VotedOn = votedAt
        };

        if (request.UserVote.VoteButton == "Positive")
        {
          voteToRegister.VotedPositive = true;
          vote.Positive = vote.Positive + 1;
        }
        if (request.UserVote.VoteButton == "Negative")
        {
          voteToRegister.VotedNegative = true;
          vote.Negative = vote.Negative + 1;
        }
        if (request.UserVote.VoteButton == "Neutral")
        {
          voteToRegister.VotedNeutral = true;
          vote.Neutral = vote.Neutral + 1;
        }
        _context.Voters.Add(voteToRegister);

        vote.LastModified = votedAt;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (success)
        {
          var voteDTO = new VoteDTO();
          _mapper.Map(vote, voteDTO);
          return Result<VoteDTO>.Success(voteDTO);
        }

        return Result<VoteDTO>.Failure("App Error, Failed to save.");





      }
    }

  }
}