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
  public class Create
  {
    public class Command : IRequest<Result<AppBackgroundTask>>
    {
      public AppBackgroundTask AppBackgroundTask { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.AppBackgroundTask.TaskName).NotEmpty().MaximumLength(500);
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

        var newTask = new AppBackgroundTask
        {
          Id = request.AppBackgroundTask.Id,
          TaskName = request.AppBackgroundTask.TaskName,
          TaskDescription = request.AppBackgroundTask.TaskDescription,
          TaskType = request.AppBackgroundTask.TaskType,
          TaskStatus = request.AppBackgroundTask.TaskStatus,
          TaskModule = request.AppBackgroundTask.TaskModule,
          TaskSubModule = request.AppBackgroundTask.TaskSubModule,
          TaskStartTime = request.AppBackgroundTask.TaskStartTime,
          TaskCreated = DateTime.Now,
          TaskCreatedBy = request.AppBackgroundTask.TaskCreatedBy,
          TaskLastUpdated = DateTime.Now,
        };

        _context.AppBackgroundTasks.Add(newTask);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<AppBackgroundTask>.Failure("Failed to create task");

        return Result<AppBackgroundTask>.Success(newTask);
      }
    }
  }

}