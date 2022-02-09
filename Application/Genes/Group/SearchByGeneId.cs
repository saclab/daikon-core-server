using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.Group
{
  public class SearchByGeneId
  {
    public class Query : IRequest<Result<List<GeneGroup>>>
    {
      public Guid GeneId { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<GeneGroup>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<GeneGroup>>> Handle(Query request, CancellationToken cancellationToken)
      {

        var geneGroupsIds = await _context.GeneGroupGenes
                                .Where(g => g.GeneId == request.GeneId)
                                .Select(g => g.GeneGroupId)
                                .Distinct().ToListAsync();
        var geneGroups = new List<GeneGroup>();

        foreach (var geneGroupId in geneGroupsIds)
        {
          var geneGroup = await _context.GeneGroups
          .Include(g => g.Genes)
          .FirstOrDefaultAsync(g => g.Id == geneGroupId);
          geneGroups.Add(geneGroup);
        }

        return Result<List<GeneGroup>>.Success(geneGroups);
      }

    }
  }
}