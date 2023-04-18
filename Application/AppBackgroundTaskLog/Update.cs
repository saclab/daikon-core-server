using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.AppBackgroundTasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
namespace Application.AppBackgroundTasksLog
{
  public class Update
  {
    public class Command : IRequest<Result<AppBackgroundTaskLog>>
    {
      public AppBackgroundTaskLog AppBackgroundTaskLog { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {

        RuleFor(cmd => cmd.AppBackgroundTaskLog.TaskName).NotEmpty().MaximumLength(50);
        RuleFor(cmd => cmd.AppBackgroundTaskLog.Id).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, Result<AppBackgroundTaskLog>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;

      private ILogger<Update> _logger;

      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor, ILogger<Update> logger)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
        _logger = logger;
      }

      public async Task<Result<AppBackgroundTaskLog>> Handle(Command request, CancellationToken cancellationToken)
      {
        var task = await _context.AppBackgroundTasksLog.FirstOrDefaultAsync(t => t.Id == request.AppBackgroundTaskLog.Id);

        if (task == null) return Result<AppBackgroundTaskLog>.Failure("Task not found");

        task.TaskName = request.AppBackgroundTaskLog.TaskName;
        task.TaskDescription = request.AppBackgroundTaskLog.TaskDescription;
        task.TaskType = request.AppBackgroundTaskLog.TaskType;
        task.TaskStatus = request.AppBackgroundTaskLog.TaskStatus;
        task.TaskModule = request.AppBackgroundTaskLog.TaskModule;
        task.TaskSubModule = request.AppBackgroundTaskLog.TaskSubModule;
        task.TaskStartTime = request.AppBackgroundTaskLog.TaskStartTime;

        task.TaskResult = request.AppBackgroundTaskLog.TaskResult;
        task.TaskResultMessage = request.AppBackgroundTaskLog.TaskResultMessage;
        task.TaskResultData = request.AppBackgroundTaskLog.TaskResultData;

        task.TaskLastUpdated = DateTime.UtcNow;
        task.TaskEndTime = request.AppBackgroundTaskLog.TaskEndTime;



        _context.AppBackgroundTasksLog.Update(task);

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

        if (!success) return Result<AppBackgroundTaskLog>.Failure("Failed to update task");

        return Result<AppBackgroundTaskLog>.Success(task);
      }
    }
  }

}