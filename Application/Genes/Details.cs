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

namespace Application.Genes
{
  public class Details
  {
    public class Query : IRequest<Result<Gene>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Gene>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }
      public async Task<Result<Gene>> Handle(Query request, CancellationToken cancellationToken)
      {
        var gene = await _context.Genes.FindAsync(request.Id);
        
        return Result<Gene>.Success(gene);
      }
    }
  }
}