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

namespace Application.Screens.ValidatedHits.Details
{
  public class ByCompoundUUID
  {
    public class Query : IRequest<Result<Hit>>
    {
      public Guid CompoundId { get; set; }
    }


    public class Handler : IRequestHandler<Query, Result<Hit>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<Hit>> Handle(Query request, CancellationToken cancellationToken)
      {

        Console.WriteLine("LOOKING FOR HIT WHERE COMPOUND ID = ");
        Console.WriteLine(request.CompoundId.GetType());

        var hit = await _context.Hits
        .FirstOrDefaultAsync(c => c.CompoundId == request.CompoundId);

        return Result<Hit>.Success(hit);
      }

    }
  }
}