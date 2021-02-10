using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Genomes
{
  public class Edit
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

        var genome = await _context.Genomes.FindAsync(request.Id);
        // Console.WriteLine(request.Id);

        if (genome == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { activity = "Not Found" });
        }

        genome.AccessionNumber = request.AccessionNumber ?? genome.AccessionNumber;
        genome.GeneName = request.GeneName ?? genome.GeneName;
        genome.Function = request.Function ?? genome.Function;
        genome.Product = request.Product ?? genome.Product;
        genome.FunctionalCategory = request.FunctionalCategory ?? genome.FunctionalCategory;

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return genome;

        throw new Exception("Problem editing  Genome");

      }
    }
  }
}