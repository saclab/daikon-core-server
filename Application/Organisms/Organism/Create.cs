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

namespace Application.Organisms
{
  public class Create
  {
    public class Command : IRequest<Result<Organism>>
    {
      public Organism Organism { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.Organism).SetValidator(new OrganismValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<Organism>>
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
      public async Task<Result<Organism>> Handle(Command request, CancellationToken cancellationToken)
      {

        // Fail if canonical name already exists
        var canonicalNameExists = await _context.Organisms.AnyAsync(o => o.CanonicalName == request.Organism.CanonicalName);
        if (canonicalNameExists) return Result<Organism>.Failure("Canonical name already exists");
        
        Guid gid = Guid.NewGuid();

        var OrganismToCreate = new Organism
        {
          Id = gid,
          Name = request.Organism.Name,
          CanonicalName = request.Organism.CanonicalName,
          GeneCount = request.Organism.GeneCount,
          GenomeSequence = request.Organism.GenomeSequence,
          Description = request.Organism.Description,

        };

        _context.Organisms.Add(OrganismToCreate);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Organism>.Failure("Failed to create Organism");
        return Result<Organism>.Success(OrganismToCreate);

      }
    }
  }
}