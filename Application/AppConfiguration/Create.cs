using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.AppConfiguration;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppConfigurations
{
  public class Create
  {
    public class Command : IRequest<Result<AppConfiguration>>
    {
      public AppConfiguration AppConfiguration { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.AppConfiguration.Key).NotEmpty().MaximumLength(50);
        RuleFor(cmd => cmd.AppConfiguration.Value).NotEmpty().MaximumLength(5000);
      }
    }

    public class Handler : IRequestHandler<Command, Result<AppConfiguration>>
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

      public async Task<Result<AppConfiguration>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Check if the key already exists
        if (await _context.AppConfigurations.AnyAsync(x => x.Key == request.AppConfiguration.Key))
          return Result<AppConfiguration>.Failure($"Key '{request.AppConfiguration.Key}' already exists");

        // Check if in JSON try to deSerialize it
        if (request.AppConfiguration.isValueInJSON)
        {
          try
          {
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject(request.AppConfiguration.Value);
          }
          catch (Exception ex)
          {
            return Result<AppConfiguration>.Failure($"Value is not a valid JSON: {ex.Message}");
          }
        }


        var config = new AppConfiguration
        {
          Id = Guid.NewGuid(),
          Key = request.AppConfiguration.Key,
          Value = request.AppConfiguration.Value,
          Component = request.AppConfiguration.Component,
          Version = 1,
          Comments = request.AppConfiguration.Comments,
          isValueInJSON = request.AppConfiguration.isValueInJSON,
          isValueInYAML = request.AppConfiguration.isValueInYAML

        };

        _context.AppConfigurations.Add(config);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<AppConfiguration>.Failure("Failed to create configuration");

        return Result<AppConfiguration>.Success(config);
      }
    }
  }

}