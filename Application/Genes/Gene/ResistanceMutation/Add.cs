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

namespace Application.Genes.ResistanceMutation
{
  public class Add
  {
    public class Command : IRequest<Result<GeneResistanceMutation>>
    {
      public GeneResistanceMutation GeneResistanceMutation { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneResistanceMutation>>
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
      public async Task<Result<GeneResistanceMutation>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Task.Delay(5000).Wait(); // Wait 2 seconds with blocking
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneResistanceMutation.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneResistanceMutation>.Failure("Invalid Gene ID");
        }

        var newGeneResistanceMutation = new GeneResistanceMutation();
        _mapper.Map(request.GeneResistanceMutation, newGeneResistanceMutation);
        newGeneResistanceMutation.Id = gid;
        newGeneResistanceMutation.GeneId = BaseGene.Id;
        newGeneResistanceMutation.GeneAccessionNumber = BaseGene.AccessionNumber;
        newGeneResistanceMutation.CreatedAt = DateTime.UtcNow;
        newGeneResistanceMutation.CreatedBy = _userAccessor.GetUsername();


        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneResistanceMutation == null)
        {
          BaseGene.GeneResistanceMutation = new List<GeneResistanceMutation>();
        }

        BaseGene.GeneResistanceMutation.Add(newGeneResistanceMutation);

        _context.GeneResistanceMutations.Add(newGeneResistanceMutation);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneResistanceMutation>.Failure("Failed to create Genome");
        return Result<GeneResistanceMutation>.Success(newGeneResistanceMutation);

      }
    }
  }
}