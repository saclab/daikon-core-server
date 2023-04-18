using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.AppBackgroundTasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.AppBackgroundTasksLog
{
  public class Create
  {
    public class Command : IRequest<Result<AppBackgroundTaskLog>>
    {
      public AppBackgroundTaskLog AppBackgroundTaskLog { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.AppBackgroundTaskLog.TaskName).NotEmpty().MaximumLength(500);
        RuleFor(cmd => cmd.AppBackgroundTaskLog.Id).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, Result<AppBackgroundTaskLog>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      private ILogger<Create> _logger;

      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor, ILogger<Create> logger)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
        _logger = logger;
      }

      public async Task<Result<AppBackgroundTaskLog>> Handle(Command request, CancellationToken cancellationToken)
      {

        var newTask = new AppBackgroundTaskLog
        {
          Id = request.AppBackgroundTaskLog.Id,
          TaskName = request.AppBackgroundTaskLog.TaskName,
          TaskDescription = request.AppBackgroundTaskLog.TaskDescription,
          TaskType = request.AppBackgroundTaskLog.TaskType,
          TaskStatus = request.AppBackgroundTaskLog.TaskStatus,
          TaskModule = request.AppBackgroundTaskLog.TaskModule,
          TaskSubModule = request.AppBackgroundTaskLog.TaskSubModule,
          TaskStartTime = request.AppBackgroundTaskLog.TaskStartTime,
          TaskCreated = DateTime.UtcNow,
          TaskCreatedBy = request.AppBackgroundTaskLog.TaskCreatedBy,
          TaskLastUpdated = DateTime.UtcNow,
        };

        _context.AppBackgroundTasksLog.Add(newTask);

        var userName = "SYSTEM";
        try
        {
          userName = _userAccessor.GetUsername();
        }
        catch (Exception)
        {
          _logger.LogWarning("Failed to get username");
        }
        var success = await _context.SaveChangesAsync(userName) > 0;


        if (!success) return Result<AppBackgroundTaskLog>.Failure("Failed to create task");

        return Result<AppBackgroundTaskLog>.Success(newTask);
      }
    }
  }

}