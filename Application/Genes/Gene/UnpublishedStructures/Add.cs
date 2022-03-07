using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.UnpublishedStructures
{
  public class Add
  {
    public class Command : IRequest<Result<GeneUnpublishedStructures>>
    {
      public GeneUnpublishedStructures GeneUnpublishedStructures { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneUnpublishedStructures>>
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
      public async Task<Result<GeneUnpublishedStructures>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Task.Delay(5000).Wait(); // Wait 2 seconds with blocking
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneUnpublishedStructures.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneUnpublishedStructures>.Failure("Invalid Gene ID");
        }

        var newGeneUnpublishedStructures = new GeneUnpublishedStructures();
        _mapper.Map(request.GeneUnpublishedStructures, newGeneUnpublishedStructures);
        newGeneUnpublishedStructures.Id = gid;
        newGeneUnpublishedStructures.GeneId = BaseGene.Id;
        newGeneUnpublishedStructures.GeneAccessionNumber = BaseGene.AccessionNumber;



        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneUnpublishedStructures == null)
        {
          BaseGene.GeneUnpublishedStructures = new List<GeneUnpublishedStructures>();
        }

        BaseGene.GeneUnpublishedStructures.Add(newGeneUnpublishedStructures);

        _context.GeneUnpublishedStructures.Add(newGeneUnpublishedStructures);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneUnpublishedStructures>.Failure("Failed to create Genome");
        return Result<GeneUnpublishedStructures>.Success(newGeneUnpublishedStructures);

      }
    }
  }
}