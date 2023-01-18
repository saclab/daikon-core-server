using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using System.Collections.Generic;
using AutoMapper;
//using Application.Errors;
using Domain;
using MediatR;
using Persistence;

// Entity framework core is required for 'include'
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Targets
{
  public class History
  {
    public class Query : IRequest<Result<List<ChangeLog>>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<ChangeLog>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<ChangeLog>>> Handle(Query request, CancellationToken cancellationToken)
      {
        //1 . Find Primary key of related tables
        var target = await _context.Targets
        .Include(t => t.TargetScorecard)
        .ThenInclude(s => s.TargetScoreCardValues)
        .FirstOrDefaultAsync(t => t.Id == request.Id);

        var answerIds = await _context.TargetScoreCardValues.Where(t => t.TargetScorecardId == target.TargetScorecard.Id)
        .Select(i => i.Id.ToString()).ToListAsync();

        var history = await _context.ChangeLogs.Where(
        h =>
        (target != null && (h.EntityName == "Target"
            && h.PrimaryKeyValue == target.Id.ToString()))
        || (target.TargetScorecard.TargetScoreCardValues != null && (h.EntityName == "TargetScoreCardValue"
            && (h.PropertyName == "Answer" || h.PropertyName == "Description")
            && answerIds.Contains(h.PrimaryKeyValue)))
        ).OrderByDescending(h => h.DateChanged).ToListAsync();

        return Result<List<ChangeLog>>.Success(history);
      }
    }
  }
}