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
  public class ByID
  {
    public class Query : IRequest<Result<Compound>>
    {
      public string ExternalCompoundIds { get; set; }
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
        .FirstOrDefaultAsync(c => c.ExternalCompoundIds == request.ExternalCompoundIds);

        return Result<Compound>.Success(compound);
      }

    }


  }
}