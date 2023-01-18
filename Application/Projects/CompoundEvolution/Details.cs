using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Projects.CompoundEvolution
{
  public class Details
  {
    public class Query : IRequest<Result<List<ProjectCompoundEvolution>>>
    {
      public Guid ProjectId { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<ProjectCompoundEvolution>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<ProjectCompoundEvolution>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var ProjectCompoundEvolutions = await _context.ProjectCompoundEvolutions
        .Include(p => p.Compound)
        .Where(p => p.ProjectId == request.ProjectId)
        .OrderByDescending(p => p.AddedOnDate)
        .ToListAsync();

        return Result<List<ProjectCompoundEvolution>>.Success(ProjectCompoundEvolutions);
      }

    }

  }
}