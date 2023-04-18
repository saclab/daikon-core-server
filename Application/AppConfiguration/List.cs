using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.AppConfigurations;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.AppConfigurations
{
  public class List
  {
    public class Query : IRequest<Result<List<AppConfiguration>>>
    {

    }



    public class Handler : IRequestHandler<Query, Result<List<AppConfiguration>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;

      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
      }

      public async Task<Result<List<AppConfiguration>>> Handle(Query request, CancellationToken cancellationToken)
      {
        // List all configurations
        var configs = await _context.AppConfigurations.ToListAsync();

        return Result<List<AppConfiguration>>.Success(configs);
      }
    }
  }

}