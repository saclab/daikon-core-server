using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Targets
{
  public class Details
  {
    public class Query : IRequest<Result<Target>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Target>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<Target>> Handle(Query request, CancellationToken cancellationToken)
      {
        var target = await _context.Targets
        .Include(t => t.TargetScorecard)
        .ThenInclude(s => s.TargetScoreCardValues)
        .ThenInclude(q => q.Question)
        .FirstOrDefaultAsync(t => t.Id == request.Id);

        return Result<Target>.Success(target);
      }

    }

  }
}