using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Errors;
using Application.Genes.DTOs;
using AutoMapper;
//using Application.Errors;
using Domain;
using MediatR;
using Persistence;

// Entity framework core is required for 'include'
using Microsoft.EntityFrameworkCore;


namespace Application.Genes
{
  public class Details
  {
    public class Query : IRequest<Result<Gene>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Gene>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<Gene>> Handle(Query request, CancellationToken cancellationToken)
      {
        var gene = await _context.Genes
        .Include(g => g.GenePublicData)
        // .Include(g => g.GeneNonPublicData)
        .Include(g => g.GeneEssentiality)
        .Include(g=> g.GeneVulnerability)
        .Include(g=> g.GeneProteinProduction)
        .Include(g=> g.GeneProteinActivityAssay)
        .Include(g=> g.GeneCRISPRiStrain)
        .Include(g=> g.GeneResistanceMutation)
        .Include(g=> g.GeneUnpublishedStructures)
        .Include(g=> g.GeneHypomorphs)
        .AsSplitQuery()
        .FirstOrDefaultAsync(g => g.Id == request.Id);
        return Result<Gene>.Success(gene);
      }
    }
  }
}