using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Errors;
//using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Genomes
{
  public class Details
  {
    public class Query : IRequest<Result<Genome>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Genome>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }
      public async Task<Result<Genome>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genome = await _context.Genomes.FindAsync(request.Id);
        
        return Result<Genome>.Success(genome);
      }
    }
  }
}