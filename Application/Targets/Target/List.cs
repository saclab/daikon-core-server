using System;
using System.Collections.Generic;
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
  public class List
  {
    public class Query : IRequest<Result<List<Target>>>
    {
     
    }

    public class Handler : IRequestHandler<Query, Result<List<Target>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<Target>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var targets = await _context.Targets
        .Include(t => t.TargetGenes)
        .ToListAsync(cancellationToken);

        return Result<List<Target>>.Success(targets);
      }

    }
  }
}