using System;
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

namespace Application.Screens
{
  public class Details
  {
    public class Query : IRequest<Result<ScreenDTO>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ScreenDTO>>
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
      public async Task<Result<ScreenDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var screen = await _context.Screens
        .Include(h => h.ValidatedHits.OrderBy(v => v.ClusterGroup))
        .ThenInclude(h => h.Compound)
        .Include(h => h.ValidatedHits)
        .ThenInclude(v => v.Vote)
        .Include(h => h.ScreenSequences)
        .Include(h => h.Org)
        .FirstOrDefaultAsync(s => s.Id == request.Id);

        var screenDTO = new ScreenDTO();
        _mapper.Map(screen, screenDTO);

        foreach (var hit in screenDTO.ValidatedHits)
        {
          var uVotes = await _context.Voters.FirstOrDefaultAsync(v => 
          (v.VoteId == hit.VoteId) && (v.VoterEmail == _userAccessor.GetUsername()));
          if (uVotes == null)
          {
            hit.Vote.HasUserVoted = false;
          }
          else
          {
            hit.Vote.HasUserVoted = true;
            if (uVotes.VotedNegative) hit.Vote.UsersVote = "Negative";
            if (uVotes.VotedPositive) hit.Vote.UsersVote = "Positive";
            if (uVotes.VotedNeutral) hit.Vote.UsersVote = "Neutral";

          }
        }
        return Result<ScreenDTO>.Success(screenDTO);
      }

    }

  }
}
