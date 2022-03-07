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

namespace Application.Genes.Hypomorph
{
  public class Add
  {
    public class Command : IRequest<Result<GeneHypomorph>>
    {
      public GeneHypomorph GeneHypomorph { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneHypomorph>>
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
      public async Task<Result<GeneHypomorph>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneHypomorph.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneHypomorph>.Failure("Invalid Gene ID");
        }

        var newGeneHypomorph = new GeneHypomorph();
        _mapper.Map(request.GeneHypomorph, newGeneHypomorph);
        newGeneHypomorph.Id = gid;
        newGeneHypomorph.GeneId = BaseGene.Id;
        newGeneHypomorph.GeneAccessionNumber = BaseGene.AccessionNumber;
        newGeneHypomorph.CreatedAt = DateTime.UtcNow;
        newGeneHypomorph.CreatedBy = _userAccessor.GetUsername();


        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneHypomorphs == null)
        {
          BaseGene.GeneHypomorphs = new List<GeneHypomorph>();
        }

        BaseGene.GeneHypomorphs.Add(newGeneHypomorph);

        _context.GeneHypomorphs.Add(newGeneHypomorph);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneHypomorph>.Failure("Failed to create Hypomorph");
        return Result<GeneHypomorph>.Success(newGeneHypomorph);

      }
    }
  }
}