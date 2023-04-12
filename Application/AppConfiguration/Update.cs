using System;
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
  public class Update
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
        var config = await _context.AppConfigurations.FirstOrDefaultAsync(c => c.Key == request.AppConfiguration.Key);

        if (config == null) return Result<AppConfiguration>.Failure("Configuration not found");

        // check if value is in JSON format and try to deserialize it
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

        // update version only if value is changed
        if (config.Value != request.AppConfiguration.Value)
        {
          config.Version++;
          config.Value = request.AppConfiguration.Value;
        }


        config.Comments = request.AppConfiguration.Comments;
        config.Component = request.AppConfiguration.Component;
        config.isValueInJSON = request.AppConfiguration.isValueInJSON;
        config.isValueInYAML = request.AppConfiguration.isValueInYAML;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<AppConfiguration>.Failure("Failed to update configuration");

        return Result<AppConfiguration>.Success(config);
      }
    }
  }

}