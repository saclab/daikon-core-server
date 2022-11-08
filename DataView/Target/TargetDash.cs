using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataView.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DataView
{
  public class TargetDash
  {

    public class Query : IRequest<Result<List<TargetDashDTO>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<TargetDashDTO>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<List<TargetDashDTO>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var targets = await _context.Targets
        .OrderBy(t => t.Name)
        .ToListAsync(cancellationToken);

        var targetDashList = new List<TargetDashDTO>();

        foreach (var target in targets)
        {
          var targetDashItem = new TargetDashDTO();
          targetDashItem.Name = target.Name;
          targetDashItem.Id = target.Id;
          targetDashItem.Type = target.Type;
          targetDashItem.Bucket = target.Bucket;
          targetDashItem.ImpactScore = target.ImpactScore;
          targetDashItem.LikeScore = target.LikeScore;
          targetDashItem.CurrentStage = "Target";

          var screen = await _context.Screens.
          FirstOrDefaultAsync(s => s.TargetName == target.Name);
          if (screen != null) targetDashItem.CurrentStage = "Screen";

          var projects = await _context.Projects.
              Where(p => p.TargetName == target.Name).ToListAsync();

          if (projects.Count != 0)
          {
            /*
            0 = HA
            1 = Portfolio
            2 = PostPortfolio
            */
            var highestState = 0;
            foreach (var project in projects)
            {
              if (project.INDEnabled || project.ClinicalP1Enabled)
              {
                highestState = 2;
              }
              else if (project.H2LEnabled || project.LOEnabled || project.SPEnabled)
              {
                highestState = highestState >= 1 ? highestState : 1;
              }
            }
            if (highestState == 0) targetDashItem.CurrentStage = "HA";
            else if (highestState == 1) targetDashItem.CurrentStage = "Portfolio";
            else targetDashItem.CurrentStage = "PostPortfolio";

          }
          targetDashList.Add(targetDashItem);
        }

        return Result<List<TargetDashDTO>>.Success(targetDashList);
      }

    }
  }
}