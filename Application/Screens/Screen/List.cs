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

namespace Application.Screens
{
  public class List
  {
    public class Query : IRequest<Result<List<Screen>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<Screen>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<Screen>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var screens = await _context.Screens
        .Where(s => s.ScreenType == ScreenType.TargetBased.Value)
        .Include(s => s.Org)
        .Include(s => s.Strain)
        .OrderBy(s => s.ScreenName)
        .ToListAsync();


        return Result<List<Screen>>.Success(screens);
      }

    }
  }
}