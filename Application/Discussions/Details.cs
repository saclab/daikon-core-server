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

namespace Application.Discussions
{
  public class Details
  {
    public class Query : IRequest<Result<List<Discussion>>>
    {
      /* Discussion are generally fetched by the RV Number*/
      public string Reference { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<Discussion>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Result<List<Discussion>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var discussion = await _context.Discussions
        .Include(r => r.Replies.OrderByDescending(r=> r.Timestamp))
        .Where(d => d.Reference == request.Reference.ToLower())
        .OrderByDescending(d => d.Timestamp)
        .ToListAsync();

        return Result<List<Discussion>>.Success(discussion);
      }



    }
  }
}