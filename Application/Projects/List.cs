using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Projects
{
  public class List
  {
    public class Query : IRequest<Result<List<Project>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<Project>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<Project>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var projects = await _context.Projects
        .Include(p => p.BaseHits)
        .ThenInclude(h => h.BaseHit)
        .Include(p => p.RepresentationStructure)
        .Include(P => P.PrimaryOrg)
        .Include(p => p.SupportingOrgs)
        .ThenInclude(o => o.AppOrg)
        .ToListAsync();

        return Result<List<Project>>.Success(projects);
      }

    }

  }
}