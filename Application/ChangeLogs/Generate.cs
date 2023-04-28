using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.ChangeLogs.DTOs;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ChangeLogs
{
  public class Generate
  {
    public class Query : IRequest<Result<List<ChangeLog>>>
    {
      public ChangeLogInputDTO ChangeLogInputDTO { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<ChangeLog>>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<List<ChangeLog>>> Handle(Query request, CancellationToken cancellationToken)
      {



        /* CASE 1 : Single Entity */
        if (!string.IsNullOrEmpty(request.ChangeLogInputDTO.Key) && request.ChangeLogInputDTO.Key.Length > 0)
        {
          //Console.WriteLine("CASE 1 : Single Entity");
          /* 1A Check if property filter is required */
          if (!string.IsNullOrEmpty(request.ChangeLogInputDTO.Property))
          {
            //Console.WriteLine("CASE 1A : Property filter is required");
            var changeLogs = await _context.ChangeLogs.Where(
              h => h.EntityName == request.ChangeLogInputDTO.Entity
              && h.PropertyName == request.ChangeLogInputDTO.Property
              && h.PrimaryKeyValue == request.ChangeLogInputDTO.Key
            ).OrderByDescending(h => h.DateChanged).ToListAsync();

            return Result<List<ChangeLog>>.Success(changeLogs);
          }
          /* 1B No property filter */
          else
          {
            //Console.WriteLine("CASE 1B : No property filter");
            var changeLogs = await _context.ChangeLogs.Where(
              h => h.EntityName == request.ChangeLogInputDTO.Entity
              && h.PrimaryKeyValue == request.ChangeLogInputDTO.Key
            ).OrderByDescending(h => h.DateChanged).ToListAsync();

            return Result<List<ChangeLog>>.Success(changeLogs);
          }

        }
        /* CASE 2 : Multiple Entities */
        else if (request.ChangeLogInputDTO.Keys != null && request.ChangeLogInputDTO.Keys.Count > 0)
        {
          /* 2A Check if property filter is required */
          //Console.WriteLine("CASE 2 : Multiple Entities");
          if (!string.IsNullOrEmpty(request.ChangeLogInputDTO.Property))
          {
            //Console.WriteLine("CASE 2A : Property filter is required");
            var changeLogs = await _context.ChangeLogs.Where(
              h => h.EntityName == request.ChangeLogInputDTO.Entity
              && h.PropertyName == request.ChangeLogInputDTO.Property
              && request.ChangeLogInputDTO.Keys.Contains(h.PrimaryKeyValue)
            ).OrderByDescending(h => h.DateChanged).ToListAsync();

            return Result<List<ChangeLog>>.Success(changeLogs);
          }
          /* 2B No property filter */
          else
          {
            //Console.WriteLine("CASE 2B : No property filter");
            var changeLogs = await _context.ChangeLogs.Where(
              h => h.EntityName == request.ChangeLogInputDTO.Entity
              && request.ChangeLogInputDTO.Keys.Contains(h.PrimaryKeyValue)
            ).OrderByDescending(h => h.DateChanged).ToListAsync();

            return Result<List<ChangeLog>>.Success(changeLogs);
          }
        }
        else
        {
          return Result<List<ChangeLog>>.Failure("No keys provided");
        }
      }
    }
  }
}