using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes
{
  public class List
  {
    public class Query : IRequest<Result<List<Gene>>> { }


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
        var genes = await _context.Genes.OrderByDescending(g => g.AccessionNumber).ToListAsync(cancellationToken);


        return Result<List<Gene>>.Success(genes);
      }
    }
  }
}