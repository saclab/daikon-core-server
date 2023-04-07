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
  public class Update
  {
    public class Command : IRequest<Result<AppBackgroundTask>>
    {
      public AppBackgroundTask AppBackgroundTask { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {

        RuleFor(cmd => cmd.AppBackgroundTask.TaskName).NotEmpty().MaximumLength(50);
        RuleFor(cmd => cmd.AppBackgroundTask.Id).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, Result<AppBackgroundTask>>
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

      public async Task<Result<AppBackgroundTask>> Handle(Command request, CancellationToken cancellationToken)
      {
        var task = await _context.AppBackgroundTasks.FirstOrDefaultAsync(t => t.Id == request.AppBackgroundTask.Id);

        if (task == null) return Result<AppBackgroundTask>.Failure("Task not found");

        task.TaskName = request.AppBackgroundTask.TaskName;
        task.TaskDescription = request.AppBackgroundTask.TaskDescription;
        task.TaskType = request.AppBackgroundTask.TaskType;
        task.TaskStatus = request.AppBackgroundTask.TaskStatus;
        task.TaskModule = request.AppBackgroundTask.TaskModule;
        task.TaskSubModule = request.AppBackgroundTask.TaskSubModule;
        task.TaskStartTime = request.AppBackgroundTask.TaskStartTime;

        task.TaskResult = request.AppBackgroundTask.TaskResult;
        task.TaskResultMessage = request.AppBackgroundTask.TaskResultMessage;
        task.TaskResultData = request.AppBackgroundTask.TaskResultData;

        task.TaskLastUpdated = DateTime.Now;
        task.TaskEndTime = request.AppBackgroundTask.TaskEndTime;



        _context.AppBackgroundTasks.Update(task);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<AppBackgroundTask>.Failure("Failed to update task");

        return Result<AppBackgroundTask>.Success(task);
      }
    }
  }

}