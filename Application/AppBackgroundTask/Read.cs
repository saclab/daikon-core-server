using System;
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
  public class Read
  {
    public class Query : IRequest<Result<AppBackgroundTask>>
    {
      public Guid Id { get; set; }
    }



    public class Handler : IRequestHandler<Query, Result<AppBackgroundTask>>
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

      public async Task<Result<AppBackgroundTask>> Handle(Query request, CancellationToken cancellationToken)
      {
        var task = await _context.AppBackgroundTasks.FirstOrDefaultAsync(t => t.Id == request.Id);

        if (task == null) return Result<AppBackgroundTask>.Failure("Configuration not found");

        return Result<AppBackgroundTask>.Success(task);
      }
    }
  }

}