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

namespace Application.Genes.ProteinActivityAssay
{
  public class Add
  {
    public class Command : IRequest<Result<GeneProteinActivityAssay>>
    {
      public GeneProteinActivityAssay GeneProteinActivityAssay { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneProteinActivityAssay>>
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
      public async Task<Result<GeneProteinActivityAssay>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Task.Delay(5000).Wait(); // Wait 2 seconds with blocking
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneProteinActivityAssay.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneProteinActivityAssay>.Failure("Invalid Gene ID");
        }

        var newGeneProteinActivityAssay = new GeneProteinActivityAssay();
        _mapper.Map(request.GeneProteinActivityAssay, newGeneProteinActivityAssay);
        newGeneProteinActivityAssay.Id = gid;
        newGeneProteinActivityAssay.GeneId = BaseGene.Id;
        newGeneProteinActivityAssay.GeneAccessionNumber = BaseGene.AccessionNumber;
        newGeneProteinActivityAssay.CreatedAt = DateTime.UtcNow;
        newGeneProteinActivityAssay.CreatedBy = _userAccessor.GetUsername();


        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneProteinActivityAssay == null)
        {
          BaseGene.GeneProteinActivityAssay = new List<GeneProteinActivityAssay>();
        }

        BaseGene.GeneProteinActivityAssay.Add(newGeneProteinActivityAssay);

        _context.GeneProteinActivityAssays.Add(newGeneProteinActivityAssay);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneProteinActivityAssay>.Failure("Failed to create Genome");
        return Result<GeneProteinActivityAssay>.Success(newGeneProteinActivityAssay);

      }
    }
  }
}