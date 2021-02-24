using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Errors;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Genomes
{
  public class Edit
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
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }
      public async Task<Result<Genome>> Handle(Command request, CancellationToken cancellationToken)
      {

        var genomeToEdit = await _context.Genomes.FindAsync(request.Genome.Id);

        if (genomeToEdit == null) return null;

        _mapper.Map(request.Genome, genomeToEdit);

        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Genome>.Failure("Failed to edit genome");

        return Result<Genome>.Success(genomeToEdit);

      }
    }
  }
}