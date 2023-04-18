using System;
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
  public class Details
  {
    public class Query : IRequest<Result<Project>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Project>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<Project>> Handle(Query request, CancellationToken cancellationToken)
      {
        var project = await _context.Projects
        .Include(s => s.Strain)
        .Include(p => p.BaseHits)
        .ThenInclude(h => h.BaseHit)
        .ThenInclude(h => h.Compound)
        .Include(p => p.RepresentationStructure)
        .Include(P => P.PrimaryOrg)
        .Include(p => p.SupportingOrgs)
        .ThenInclude(o => o.AppOrg)
        .FirstOrDefaultAsync(p => p.Id == request.Id);

        return Result<Project>.Success(project);
      }

    }

  }
}