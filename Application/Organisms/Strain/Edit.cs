using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Organisms.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Strains
{
  public class Edit
  {
    public class Command : IRequest<Result<Strain>>
    {
      public Strain Strain { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.Strain).SetValidator(new StrainValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<Strain>>
    {
      private readonly DataContext _context;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IUserAccessor userAccessor)
      {
        _context = context;
        _userAccessor = userAccessor;
      }


      public async Task<Result<Strain>> Handle(Command request, CancellationToken cancellationToken)
      {
        var strain = await _context.Strains.FirstOrDefaultAsync(s => s.Id == request.Strain.Id);

        if (strain == null) return Result<Strain>.Failure("Invalid Strain Id");

        // Check if OrganismId is changed
        if (request.Strain.OrganismId != null && (strain.OrganismId != request.Strain.OrganismId))
        {
          var organism = await _context.Organisms.FirstOrDefaultAsync(o => o.Id == request.Strain.OrganismId);
          if (organism == null) return Result<Strain>.Failure("Invalid Organism Id");
          strain.OrganismId = organism.Id;
        }

        strain.Name = request.Strain.Name ?? strain.Name;
        strain.CanonicalName = request.Strain.CanonicalName ?? strain.CanonicalName;
        strain.DrugResistanceLevel = request.Strain.DrugResistanceLevel != 0 ? request.Strain.DrugResistanceLevel : strain.DrugResistanceLevel;
        strain.GenomeSequence = request.Strain.GenomeSequence ?? strain.GenomeSequence;
        strain.Description = request.Strain.Description ?? strain.Description;

        var result = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!result) return Result<Strain>.Failure("Failed to update strain");

        return Result<Strain>.Success(strain);
      }
    }
  }
}