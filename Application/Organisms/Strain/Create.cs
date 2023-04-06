using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes;
using Application.Interfaces;
using Application.Organisms.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Strains
{
  public class Create
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
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
      }
      public async Task<Result<Strain>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Check if Organism exists
        var organism = await _context.Organisms.FirstOrDefaultAsync(o => o.Id == request.Strain.OrganismId);
        if (organism == null) return Result<Strain>.Failure("Organism does not exist");

        // Check if Strain Canonical Name already exists
        var strainExists = await _context.Organisms.AnyAsync(o => o.CanonicalName == request.Strain.CanonicalName);
        if (strainExists) return Result<Strain>.Failure("Strain already exists");


        Guid gid = Guid.NewGuid();
        var StrainToCreate = new Strain
        {
          Id = gid,
          Name = request.Strain.Name,
          CanonicalName = request.Strain.CanonicalName,
          OrganismId = organism.Id,
          Description = request.Strain.Description,
          GenomeSequence = request.Strain.GenomeSequence,
          DrugResistanceLevel = request.Strain.DrugResistanceLevel,
        };

        _context.Strains.Add(StrainToCreate);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Strain>.Failure("Failed to create Strain");
        return Result<Strain>.Success(StrainToCreate);

      }
    }
  }
}