using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Genomes
{
  public class Details
  {
    public class Query : IRequest<Genome>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Genome>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }
      public async Task<Genome> Handle(Query request, CancellationToken cancellationToken)
      {
        var genome = await _context.Genomes.FindAsync(request.Id);

        return genome;
      }
    }
  }
}