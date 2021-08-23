using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Genes
{
  public class Delete
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {

        var geneToDelete = await _context.Genes.FindAsync(request.Id);

        if (geneToDelete == null) return null;

        _context.Remove(geneToDelete);

        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Unit>.Failure("Failed to delete Genome");

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}