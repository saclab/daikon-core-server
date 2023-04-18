using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using Application.Global.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes
{
  public class List
  {
    public class Query : IRequest<Result<List<Gene>>>
    {
      public Guid StrainFilter { get; set; }
    }


    public class Handler : IRequestHandler<Query, Result<List<Gene>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<Gene>>> Handle(Query request, CancellationToken cancellationToken)
      {
        List<Gene> genes;

        if (request.StrainFilter != Guid.Empty)
        {
          genes = await _context.Genes.Where(
            g => g.StrainId == request.StrainFilter
            ).OrderBy(g => g.GeneName).ToListAsync(cancellationToken);
          return Result<List<Gene>>.Success(genes);
        }
        else
        {
          genes = await _context.Genes.OrderBy(g => g.GeneName).ToListAsync(cancellationToken);
        }
        return Result<List<Gene>>.Success(genes);
      }
    }
  }
}