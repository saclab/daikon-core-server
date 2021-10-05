using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Screens.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens
{
  public class List
  {
    public class Query : IRequest<Result<List<ScreenListDTO>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<ScreenListDTO>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<ScreenListDTO>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var screens =  await _context.Screens
        .Include(h => h.Hits)
        .Select(s => new ScreenListDTO()
        {
          Id = s.Id,
          TargetId = s.TargetId,
          ScreenName = s.ScreenName,
          AccessionNumber = s.AccessionNumber,
          GeneName = s.GeneName,
          Status = s.Status,
          Library = s.Library,
          Scientist = s.Scientist,
          StartDate = s.StartDate,
          EndDate = s.EndDate,
          Method = s.Method,
          Protocol = s.Protocol,
          Comment = s.Comment,
          hitCount = s.Hits.Count

        }).ToListAsync();


        return Result<List<ScreenListDTO>>.Success(screens);
      }

    }
  }
}