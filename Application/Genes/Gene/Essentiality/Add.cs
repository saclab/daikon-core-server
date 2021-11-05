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

namespace Application.Genes.Essentiality
{
  public class Add
  {
    public class Command : IRequest<Result<GeneEssentiality>>
    {
      public GeneEssentiality GeneEssentiality { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneEssentiality>>
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
      public async Task<Result<GeneEssentiality>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Task.Delay(5000).Wait(); // Wait 2 seconds with blocking
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneEssentiality.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneEssentiality>.Failure("Invalid Gene ID");
        }

        var newGeneEssentiality = new GeneEssentiality();
        _mapper.Map(request.GeneEssentiality, newGeneEssentiality);
        newGeneEssentiality.Id = gid;
        newGeneEssentiality.GeneId = BaseGene.Id;
        newGeneEssentiality.GeneAccessionNumber = BaseGene.AccessionNumber;


        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneEssentiality == null)
        {
          BaseGene.GeneEssentiality = new List<GeneEssentiality>();
        }

        BaseGene.GeneEssentiality.Add(newGeneEssentiality);

        _context.GeneEssentiality.Add(newGeneEssentiality);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneEssentiality>.Failure("Failed to create Genome");
        return Result<GeneEssentiality>.Success(newGeneEssentiality);

      }
    }
  }
}