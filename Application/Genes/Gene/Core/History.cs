using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using System.Collections.Generic;
using AutoMapper;
//using Application.Errors;
using Domain;
using MediatR;
using Persistence;

// Entity framework core is required for 'include'
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Genes
{
  public class History
  {
    public class Query : IRequest<Result<List<ChangeLog>>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<ChangeLog>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<ChangeLog>>> Handle(Query request, CancellationToken cancellationToken)
      {
        //1 . Find Primary key of related tables
        var gene = await _context.Genes
          .Include(g => g.GenePublicData)
          // .Include(g => g.GeneNonPublicData)
          .Include(g => g.GeneEssentiality)
          .Include(g => g.GeneVulnerability)
          .AsSplitQuery()
          .FirstOrDefaultAsync(g => g.Id == request.Id);


        var history = await _context.ChangeLogs.Where(
            h =>
            (gene.GenePublicData != null && (h.EntityName == "GenePublicData"
                && h.PrimaryKeyValue == gene.GenePublicData.Id.ToString()))
            // || (gene.GeneNonPublicData != null && (h.EntityName == "GeneNonPublicData"
            //     && h.PrimaryKeyValue == gene.GeneNonPublicData.Id.ToString()))
            || (gene != null && (h.EntityName == "Gene"
                && h.PrimaryKeyValue == gene.Id.ToString()))
            ).OrderByDescending(h => h.DateChanged).ToListAsync();

        return Result<List<ChangeLog>>.Success(history);
      }
    }
  }
}