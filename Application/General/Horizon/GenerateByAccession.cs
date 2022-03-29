using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.General.Horizon.DTO;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.General.Horizon
{
  public class GenerateByAccession
  {
    public class Query : IRequest<Result<HorizonAccessionRoot>>
    {
      public String AccessionNumber { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<HorizonAccessionRoot>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<HorizonAccessionRoot>> Handle(Query request, CancellationToken cancellationToken)
      {

        var gene = await _context.Genes
          .FirstOrDefaultAsync(g => g.AccessionNumber == request.AccessionNumber);

        if (gene == null)
        {
          return Result<HorizonAccessionRoot>.Failure("Invalid accession number");
        }

        var HorizonAccessionRoot = new HorizonAccessionRoot()
        {
          Name = "Gene",
          Attributes = {
                Id = gene.Id,
                AccessionNumber = gene.AccessionNumber,
                RootName = gene.GeneName,
            }

        };

        // Now find all the target id's that the gene belongs to
        // so this gene group id will have both simple and complex proteins

        var targetIds = await _context.TargetGenes
                                .Where(g => g.GeneId == gene.Id)
                                .Select(g => g.TargetId)
                                .Distinct().ToListAsync();

        if (targetIds.Count() == 0)
        {
          return Result<HorizonAccessionRoot>.Success(HorizonAccessionRoot);
        }

        HorizonAccessionRoot.Children = new List<HorizonRoot>();




        foreach (var targetId in targetIds)
        {
          /*Now lets fetch the targets, at this point we know the targets */
          var target = await _context.Targets
            .Include(t => t.TargetGenes)
            .FirstOrDefaultAsync(t => t.Id == targetId);

          var horizonRoot = new HorizonRoot();
          horizonRoot.Children = new List<HorizonTarget>();

          horizonRoot.Attributes.TargetName = target.Name;

          if (target.Type == "simple-protein")
          {
            horizonRoot.Name = "SimpleProtein";
            horizonRoot.Attributes.Id = target.TargetGenes.First().GeneId;
            horizonRoot.Attributes.AccessionNumber = target.TargetGenes.First().AccessionNumber;
          }

          if (target.Type == "protein-complex")
          {
            horizonRoot.Name = "ProteinComplex";
            var accessionNumbers = new List<string>();
            foreach (var targetGene in target.TargetGenes)
            {
              accessionNumbers.Add(targetGene.AccessionNumber);
            }
            horizonRoot.Attributes.AccessionNumbers = accessionNumbers;
          }

          var horizonTarget = new HorizonTarget
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
            HorizonAccessionRoot.Children.Add(horizonRoot);
            break;
          }

          horizonTarget.Children = new List<HorizonScreen>();
          foreach (var screen in screens)
          {
            var horizonScreen = new HorizonScreen
            {
              Name = "Screen",
              Attributes = {
                  Id = screen.Id,
                  ScreenName = screen.ScreenName,
                  TargetName = screen.TargetName

              }
            };
            horizonTarget.Children.Add(horizonScreen);

            // Start nesting from here
            var projects = await _context.Projects.Where(p => p.ScreenId == screen.Id).ToListAsync();
            if (projects != null)
            {
              horizonScreen.Children = new List<HorizonFHA>();
              foreach (var project in projects)
              {
                var horizionFHA = new HorizonFHA
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
                  var horizonPortfolio = new HorizonPortfolio
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

                  if (project.INDEnabled || project.ClinicalP1Enabled)
                  {
                    var horizionPostPortfolio = new HorizonPostPortfolio
                    {
                      Name = "PostPortfolio",
                      Attributes =
                  {
                  Id = project.Id,
                  TargetName = project.TargetName,
                  ProjectName = project.ProjectName,
                  Status = project.Status,
                  CurrentStage = project.CurrentStage
                  }
                    };

                    horizonPortfolio.Children = new List<HorizonPostPortfolio>();
                    horizonPortfolio.Children.Add(horizionPostPortfolio);
                  }


                  horizionFHA.Children = new List<HorizonPortfolio>();
                  horizionFHA.Children.Add(horizonPortfolio);

                }

                horizonScreen.Children.Add(horizionFHA);
              }
            }

          }
          HorizonAccessionRoot.Children.Add(horizonRoot);

        }

        return Result<HorizonAccessionRoot>.Success(HorizonAccessionRoot);
      }
    }
  }
}