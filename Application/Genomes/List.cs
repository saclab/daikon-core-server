using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genomes
{
  public class List
  {
    public class Query : IRequest<Result<List<Genome>>> { }


    public class Handler : IRequestHandler<Query, Result<List<Genome>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<Genome>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genomes = await _context.Genomes.ToListAsync(cancellationToken);
        
        return Result<List<Genome>>.Success(genomes);
      }
    }
  }
}