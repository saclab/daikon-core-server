using System.Collections.Generic;
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
    public class Query : IRequest<Result<List<GeneListDTO>>> { }


    public class Handler : IRequestHandler<Query, Result<List<GeneListDTO>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<GeneListDTO>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genes = await _context.Genes.ToListAsync(cancellationToken);
        var genesToReturn = _mapper.Map<List<GeneListDTO>>(genes);
        return Result<List<GeneListDTO>>.Success(genesToReturn);
      }
    }
  }
}