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
  public class Details
  {
    public class Query : IRequest<Result<GeneGroup>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GeneGroup>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<GeneGroup>> Handle(Query request, CancellationToken cancellationToken)
      {
        var geneGroup = await _context.GeneGroups
        .Include(g => g.Genes)
        .ThenInclude(g => g.Gene)
        .FirstOrDefaultAsync(g => g.Id == request.Id);

        return Result<GeneGroup>.Success(geneGroup);
      }

    }
  }
}