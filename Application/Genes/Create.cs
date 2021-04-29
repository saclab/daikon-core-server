using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Genes
{
  public class Create
  {
    public class Command : IRequest<Result<Gene>>
    {
      public Gene Gene { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<Gene>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Result<Gene>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid gid = Guid.NewGuid();
        var GeneToCreate = new Gene
        {
          Id = gid,
          AccessionNumber = request.Gene.AccessionNumber,
          GeneName = request.Gene.GeneName,
          Function = request.Gene.Function,
          Product = request.Gene.Product,
          FunctionalCategory = request.Gene.FunctionalCategory
        };

        _context.Genes.Add(GeneToCreate);
        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Gene>.Failure("Failed to create Genome");
        return Result<Gene>.Success(GeneToCreate);

      }
    }
  }
}