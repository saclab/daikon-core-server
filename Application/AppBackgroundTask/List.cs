using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.AppBackgroundTasks;
using Domain.AppConfiguration;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.AppBackgroundTasks
{
  public class List
  {
    public class Query : IRequest<Result<List<AppBackgroundTask>>>
    {

    }



    public class Handler : IRequestHandler<Query, Result<List<AppBackgroundTask>>>
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

      public async Task<Result<List<AppBackgroundTask>>> Handle(Query request, CancellationToken cancellationToken)
      {
        // List all configurations
        var tasks = await _context.AppBackgroundTasks.ToListAsync();

        return Result<List<AppBackgroundTask>>.Success(tasks);
      }
    }
  }

}