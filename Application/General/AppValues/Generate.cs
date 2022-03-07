using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.General.AppValues.DTO;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.General.AppValues
{
  public class Generate
  {
    public class Query : IRequest<Result<AppValuesDTO>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<AppValuesDTO>>
    {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Result<AppValuesDTO>> Handle(Query request, CancellationToken cancellationToken)
      {

        var appValues = new AppValuesDTO();


        var orgs = await _context.AppOrgs.ToListAsync();
        appValues.AppOrgs = new List<AppOrg>(orgs);
        appValues.AppOrgsFlattened = new List<string>();
        appValues.AppOrgsAliasFlattened = new List<string>();
        foreach (var org in orgs)
        {
          appValues.AppOrgsFlattened.Add(org.Name);
          appValues.AppOrgsAliasFlattened.Add(org.Alias);
        }

        var users = await _context.Users.ToListAsync();
        appValues.AppUsersFlattened = new List<string>();
        foreach (var user in users)
        {
          appValues.AppUsersFlattened.Add(user.UserName);
        }

        var screeningMethods = await _context.AppVals.Where(a => a.Key == "ScreeningMethod")
          .ToListAsync();

        appValues.ScreeningMethods = new List<string>(screeningMethods.Select(e => e.Value)
          .ToList());

        return Result<AppValuesDTO>.Success(appValues);
      }
    }
  }
}