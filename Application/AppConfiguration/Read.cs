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
  public class Read
  {
    public class Query : IRequest<Result<AppConfiguration>>
    {
      public string Key { get; set; }
    }



    public class Handler : IRequestHandler<Query, Result<AppConfiguration>>
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

      public async Task<Result<AppConfiguration>> Handle(Query request, CancellationToken cancellationToken)
      {
        var config = await _context.AppConfigurations.FirstOrDefaultAsync(c => c.Key == request.Key);

        if (config == null) return Result<AppConfiguration>.Failure("Configuration not found");

        return Result<AppConfiguration>.Success(config);
      }
    }
  }

}