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

namespace Application.Genes.ProteinProduction
{
  public class Add
  {
    public class Command : IRequest<Result<GeneProteinProduction>>
    {
      public GeneProteinProduction GeneProteinProduction { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneProteinProduction>>
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
      public async Task<Result<GeneProteinProduction>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Task.Delay(5000).Wait(); // Wait 2 seconds with blocking
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneProteinProduction.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneProteinProduction>.Failure("Invalid Gene ID");
        }

        var newGeneProteinProduction = new GeneProteinProduction();
        _mapper.Map(request.GeneProteinProduction, newGeneProteinProduction);
        newGeneProteinProduction.Id = gid;
        newGeneProteinProduction.GeneId = BaseGene.Id;
        newGeneProteinProduction.GeneAccessionNumber = BaseGene.AccessionNumber;
        newGeneProteinProduction.CreatedAt = DateTime.UtcNow;
        newGeneProteinProduction.CreatedBy = _userAccessor.GetUsername();


        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneProteinProduction == null)
        {
          BaseGene.GeneProteinProduction = new List<GeneProteinProduction>();
        }

        BaseGene.GeneProteinProduction.Add(newGeneProteinProduction);

        _context.GeneProteinProductions.Add(newGeneProteinProduction);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneProteinProduction>.Failure("Failed to add GeneProteinProduction");
        return Result<GeneProteinProduction>.Success(newGeneProteinProduction);

      }
    }
  }
}