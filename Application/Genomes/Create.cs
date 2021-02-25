using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Genomes
{
  public class Create
  {
    public class Command : IRequest<Result<Genome>>
    {
      public Genome Genome { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.Genome).SetValidator(new GenomeValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<Genome>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Result<Genome>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid gid = Guid.NewGuid();
        var genomeToCreate = new Genome
        {
          Id = gid,
          AccessionNumber = request.Genome.AccessionNumber,
          GeneName = request.Genome.GeneName,
          Function = request.Genome.Function,
          Product = request.Genome.Product,
          FunctionalCategory = request.Genome.FunctionalCategory
        };

        _context.Genomes.Add(genomeToCreate);
        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Genome>.Failure("Failed to create Genome");
        return Result<Genome>.Success(genomeToCreate);

      }
    }
  }
}