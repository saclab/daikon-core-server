using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.Group
{
  public class Create
  {
    public class Command : IRequest<Result<GeneGroup>>
    {
      public GeneGroup GeneGroup { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneGroup>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
      }
      public async Task<Result<GeneGroup>> Handle(Command request, CancellationToken cancellationToken)
      {

        var checkIfExists = await _context.GeneGroups.FirstOrDefaultAsync(g => g.Name == request.GeneGroup.Name);
        if (checkIfExists != null)
        {
          return Result<GeneGroup>.Failure("Gene Group Already Exists");
        }


        Guid gid = Guid.NewGuid();

        var geneGroupToCreate = new GeneGroup()
        {
          Id = gid,
          Name = request.GeneGroup.Name,
          Type = request.GeneGroup.Type,
          Genes = new List<GeneGroupGenes>()
        };

        foreach (var gene in request.GeneGroup.Genes)
        {
          var geneToAdd = await _context.Genes.FirstOrDefaultAsync(g => g.Id == gene.GeneId);
          var newGeneGroupGenes = new GeneGroupGenes()
          {
            Id = new Guid(),
            GeneGroupId = gid,
            GeneId = geneToAdd.Id,
            Gene = geneToAdd,
            AccessionNumber = geneToAdd.AccessionNumber
          };
          geneGroupToCreate.Genes.Add(newGeneGroupGenes);
          _context.GeneGroupGenes.Add(newGeneGroupGenes);
        }

        _context.GeneGroups.Add(geneGroupToCreate);


        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<GeneGroup>.Failure("Failed to create Gene Group");
        return Result<GeneGroup>.Success(geneGroupToCreate);

      }
    }
  }
}