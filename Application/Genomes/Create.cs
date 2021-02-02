using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Genomes
{
  public class Create
  {
    public class Command : IRequest<Genome>
    {
      public Guid Id { get; set; }
      public string AccessionNumber { get; set; }
      public string GeneName { get; set; }
      public string Function { get; set; }
      public string Product { get; set; }
      public string FunctionalCategory { get; set; }
    }

    public class Handler : IRequestHandler<Command, Genome>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Genome> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid gid = Guid.NewGuid();
        var genome = new Genome
        {
          Id = gid,
          AccessionNumber = request.AccessionNumber,
          GeneName = request.GeneName,
          Function = request.Function,
          Product = request.Product,
          FunctionalCategory = request.FunctionalCategory
        };

        _context.Genomes.Add(genome);
        var success = await _context.SaveChangesAsync() > 0;

        if (success) return genome;

        throw new Exception("Problem adding new Genome");

      }
    }
  }
}