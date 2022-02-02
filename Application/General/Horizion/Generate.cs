using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.General.Horizion.DTO;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.General.Horizion
{
  public class Generate
  {
    public class Query : IRequest<Result<HorizionRoot>>
    {
      public String TargetName { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<HorizionRoot>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<HorizionRoot>> Handle(Query request, CancellationToken cancellationToken)
      {

        // var gene = await _context.Genes
        //   .FirstOrDefaultAsync(g => g.AccessionNumber == request.AccessionNumber);

        // if (gene == null)
        // {
        //   return Result<HorizionGene>.Failure("Invalid accession number");
        // }

        var horizonRoot = new HorizionRoot();
        horizonRoot.Children = new List<HorizionTarget>();
        // {
        //   Name = "Gene",
        //   Attributes = {
        //         Id = gene.Id,
        //         AccessionNumber = gene.AccessionNumber,
        //         GeneName = gene.GeneName,
        //     }

        // };


        /*Now lets check if we have a target */
        var target = await _context.Targets
          .Include(t => t.TargetGenes)
          .FirstOrDefaultAsync(t => t.Name == request.TargetName);

        if (target == null)
        {
          return Result<HorizionRoot>.Failure("The Target Does Not Exists");
        }

        horizonRoot.Attributes.TargetName = target.Name;

        if (target.Type == "simple-protein")
        {
          horizonRoot.Name = "Gene";
          horizonRoot.Attributes.Id = target.TargetGenes.First().GeneId;
          horizonRoot.Attributes.AccessionNumber = target.TargetGenes.First().AccessionNumber;
        }

        if (target.Type == "protein-complex")
        {
          horizonRoot.Name = "GeneGroup";
        }

        var horizonTarget = new HorizionTarget
        {
          Name = "Target",
          Attributes = {
                Id = target.Id,
                TargetName = target.Name,
                TargetType = target.Type,
                BucketScore = target.Bucket
            }
        };

        horizonRoot.Children.Add(horizonTarget);


        /* Now lets check for screens */

        var screens = await _context.Screens.Where(s => s.TargetId == target.Id)
        .ToListAsync();

        if (screens == null)
        {
          return Result<HorizionRoot>.Success(horizonRoot);
        }

        horizonTarget.Children = new List<HorizionScreen>();
        foreach (var screen in screens)
        {
          var horizionScreen = new HorizionScreen
          {
            Name = "Screen",
            Attributes = {
                  Id = screen.Id,
                  ScreenName = screen.ScreenName,
                  TargetName = screen.TargetName

              }
          };
          horizonTarget.Children.Add(horizionScreen);

          // Start nesting from here
          var projects = await _context.Projects.Where(p => p.ScreenId == screen.Id).ToListAsync();
          if (projects != null)
          {
            horizionScreen.Children = new List<HorizionFHA>();
            foreach (var project in projects)
            {
              var horizionFHA = new HorizionFHA
              {
                Name = "FHA",
                Attributes = {
                  Id = project.Id,
                  TargetName = project.TargetName,
                  ProjectName = project.ProjectName,
                  Status = project.Status,
                }
              };

              // now check if it has a portfolio

              if (project.H2LEnabled || project.LOEnabled || project.SPEnabled)
              {
                var horizionPortfolio = new HorizionPortfolio
                {
                  Name = "Portfolio",
                  Attributes =
                  {
                  Id = project.Id,
                  TargetName = project.TargetName,
                  ProjectName = project.ProjectName,
                  Status = project.Status,
                  CurrentStage = project.CurrentStage
                  }
                };

                /* Insetr new if ans post portfolio */
                // {if}


                horizionFHA.Children = new List<HorizionPortfolio>();
                horizionFHA.Children.Add(horizionPortfolio);

              }

              horizionScreen.Children.Add(horizionFHA);
            }
          }
        }


        return Result<HorizionRoot>.Success(horizonRoot);
      }
    }
  }
}