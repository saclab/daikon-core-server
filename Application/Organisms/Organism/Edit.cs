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

namespace Application.Organisms
{
  public class Edit
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
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IUserAccessor userAccessor)
      {
        _context = context;
        _userAccessor = userAccessor;
      }


      public async Task<Result<Organism>> Handle(Command request, CancellationToken cancellationToken)
      {
        var organism = await _context.Organisms.FirstOrDefaultAsync(o => o.Id == request.Organism.Id);

        if (organism == null) return Result<Organism>.Failure("Invalid Organism Id");

        organism.Name = request.Organism.Name ?? organism.Name;
        organism.CanonicalName = request.Organism.CanonicalName ?? organism.CanonicalName;
        organism.GeneCount = request.Organism.GeneCount != 0 ? request.Organism.GeneCount : organism.GeneCount;
        organism.GenomeSequence = request.Organism.GenomeSequence ?? organism.GenomeSequence;
        organism.Description = request.Organism.Description ?? organism.Description;

        var result = false;
        try {
          result = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;
        }
        catch (Exception e) {
          Console.WriteLine(e.Message);
        }

         

        if (!result) return Result<Organism>.Failure("Failed to update organism");

        return Result<Organism>.Success(organism);
      }
    }


  }
}