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

namespace Application.Compounds
{
  public class List
  {
    public class Query : IRequest<Result<List<Compound>>>
    {

    }


    public class Handler : IRequestHandler<Query, Result<List<Compound>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<Compound>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var compound = await _context.Compounds
        .ToListAsync();

        return Result<List<Compound>>.Success(compound);
      }

    }


  }
}