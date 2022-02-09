using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.Group
{
  public class List
  {
    public class Query : IRequest<Result<List<GeneGroup>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<GeneGroup>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<GeneGroup>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var geneGroups = await _context.GeneGroups
        .Include(g => g.Genes)
        .ToListAsync(cancellationToken);

        return Result<List<GeneGroup>>.Success(geneGroups);
      }

    }
  }
}