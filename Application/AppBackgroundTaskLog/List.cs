using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.AppBackgroundTasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.AppBackgroundTasksLog
{
  public class List
  {
    public class Query : IRequest<Result<List<AppBackgroundTaskLog>>>
    {

    }



    public class Handler : IRequestHandler<Query, Result<List<AppBackgroundTaskLog>>>
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

      public async Task<Result<List<AppBackgroundTaskLog>>> Handle(Query request, CancellationToken cancellationToken)
      {
        // List all configurations
        var tasks = await _context.AppBackgroundTasksLog.ToListAsync();

        return Result<List<AppBackgroundTaskLog>>.Success(tasks);
      }
    }
  }

}