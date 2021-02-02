using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genomes
{
  public class List
  {
    public class Query : IRequest<List<Genome>> { }


    public class Handler : IRequestHandler<Query, List<Genome>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }
      public async Task<List<Genome>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genomes = await _context.Genomes.ToListAsync();

        return genomes;
      }
    }
  }
}