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

namespace Application.Compounds.Details
{
  /*
  WARNING: String matching of smile string is not the right way to search
  Smile search algo needs to be implemented
  */
  public class BySMILE
  {
    public class Query : IRequest<Result<Compound>>
    {
      public string SMILE { get; set; }
    }


    public class Handler : IRequestHandler<Query, Result<Compound>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<Compound>> Handle(Query request, CancellationToken cancellationToken)
      {
        var compound = await _context.Compounds
        .FirstOrDefaultAsync(c => c.Smile == request.SMILE);

        return Result<Compound>.Success(compound);
      }

    }


  }
}