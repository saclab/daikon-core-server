using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.General.Horizon.DTO;
using Application.Screens;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.General.Horizon
{
  public class Generate
  {
    public class Query : IRequest<Result<HorizonRoot>>
    {
      public String TargetName { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<HorizonRoot>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<HorizonRoot>> Handle(Query request, CancellationToken cancellationToken)
      {

        // var gene = await _context.Genes
        //   .FirstOrDefaultAsync(g => g.AccessionNumber == request.AccessionNumber);

        // if (gene == null)
        // {
        //   return Result<HorizonGene>.Failure("Invalid accession number");
        // }

        var horizonRoot = new HorizonRoot();

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

          /* Check if it has screen */
          var checkScreen = await _context.Screens.Where((s) => (s.ScreenName.Contains(request.TargetName)
                                                            ) && (s.ScreenType == ScreenType.Phenotypic.Value))
                                                            .OrderByDescending(s => s.ScreenName).ToListAsync();

          if (!checkScreen.Any())
          {
            /* check if it is an unlinked project */
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectName == request.TargetName);

            if (project == null)
            {
              return Result<HorizonRoot>.Failure("The Target Does Not Exists");
            }
            horizonRoot.Children = new List<HorizonTarget>();
            horizonRoot.Name = "Gene";
            horizonRoot.Attributes.AccessionNumber = "Unknown";
            horizonRoot.Attributes.TargetName=request.TargetName;

            var blankHorizonTarget = new HorizonTarget
            {
              Name = "Target",
              Attributes = {
                TargetName = "Unknown",
                TargetType = "simple-protein",
            }
            };

            horizonRoot.Children.Add(blankHorizonTarget);

            blankHorizonTarget.Children = new List<HorizonScreen>();

            var blankHorizonScreen = new HorizonScreen
            {
              Name = "Screen",
              Attributes = {

                  ScreenName = "Unknown",
                  TargetName = "Unknown",
                  ScreenMethod = "Phenotypic"

              }
            };
            blankHorizonTarget.Children.Add(blankHorizonScreen);

            blankHorizonScreen.Children = new List<HorizonFHA>();
            var unlinkedHorizionFHA = new HorizonFHA
            {
              Name = "FHA",
              Attributes = {
                  Id = project.Id,
                  TargetName = "Unknown",
                  ProjectName = project.ProjectName,
                  Status = project.Status,
                }
            };

            if (project.H2LEnabled || project.LOEnabled || project.SPEnabled)
            {
              var unlinkedHorizonPortfolio = new HorizonPortfolio
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

              if (project.INDEnabled || project.ClinicalP1Enabled)
              {
                var unlinkedHorizionPostPortfolio = new HorizonPostPortfolio
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

                unlinkedHorizonPortfolio.Children = new List<HorizonPostPortfolio>();
                unlinkedHorizonPortfolio.Children.Add(unlinkedHorizionPostPortfolio);
              }

              unlinkedHorizionFHA.Children = new List<HorizonPortfolio>();
              unlinkedHorizionFHA.Children.Add(unlinkedHorizonPortfolio);

            }

            blankHorizonScreen.Children.Add(unlinkedHorizionFHA);

            return Result<HorizonRoot>.Success(horizonRoot);

          }

          horizonRoot.Children = new List<HorizonTarget>();
          horizonRoot.Name = "Gene";
          horizonRoot.Attributes.AccessionNumber = "Unknown";
          horizonRoot.Attributes.TargetName=request.TargetName;

          var blankHorizonTarget2 = new HorizonTarget
          {
            Name = "Target",
            Attributes = {
                TargetName = "Unknown",
                TargetType = "simple-protein",
            }
          };

          horizonRoot.Children.Add(blankHorizonTarget2);

          blankHorizonTarget2.Children = new List<HorizonScreen>();



          var screens2 = await _context.Screens.Where((s) => (s.ScreenName.Contains(request.TargetName)
                                                            ) && (s.ScreenType == ScreenType.Phenotypic.Value))
                                                            .OrderByDescending(s => s.ScreenName).ToListAsync();




          blankHorizonTarget2.Children = new List<HorizonScreen>();
          foreach (var screen in screens2)
          {
            var horizonScreen = new HorizonScreen
            {
              Name = "Screen",
              Attributes = {
                  Id = screen.Id,
                  ScreenName = screen.ScreenName,
                  TargetName = "Phenotypic",
                  ScreenMethod = "Phenotypic"
              }
            };
            blankHorizonTarget2.Children.Add(horizonScreen);


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

                  /* Insetr new if ans post portfolio */
                  // {if}

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
          return Result<HorizonRoot>.Success(horizonRoot);
        }






        horizonRoot.Children = new List<HorizonTarget>();

        horizonRoot.Attributes.TargetName = target.Name;

        if (target.Type == "simple-protein")
        {
          horizonRoot.Name = "Gene";
          horizonRoot.Attributes.Id = target.TargetGenes.First().GeneId;
          horizonRoot.Attributes.AccessionNumber = target.TargetGenes.First().AccessionNumber;
        }

        if (target.Type == "protein-complex")
        {
          horizonRoot.Name = "ProteinComplex";
          var accessionNumbers = new List<string>();
          foreach (var gene in target.TargetGenes)
          {
            accessionNumbers.Add(gene.AccessionNumber);
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
          return Result<HorizonRoot>.Success(horizonRoot);
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
                  TargetName = screen.TargetName,
                  ScreenMethod = screen.Method

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

                /* Insetr new if ans post portfolio */
                // {if}

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


        return Result<HorizonRoot>.Success(horizonRoot);
      }
    }
  }
}