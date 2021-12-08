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
    public class Query : IRequest<Result<HorizionGene>>
    {
      public String AccessionNumber { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<HorizionGene>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<HorizionGene>> Handle(Query request, CancellationToken cancellationToken)
      {

        var gene = await _context.Genes
          .FirstOrDefaultAsync(g => g.AccessionNumber == request.AccessionNumber);

        if (gene == null)
        {
          return Result<HorizionGene>.Failure("Invalid accession number");
        }

        var horizonGene = new HorizionGene
        {
          Name = "Gene",
          Attributes = {
                Id = gene.Id,
                AccessionNumber = gene.AccessionNumber,
                GeneName = gene.GeneName,
            }

        };


        /*Now lets check if we have a target */
        var target = await _context.Targets
          .FirstOrDefaultAsync(t => t.GeneId == gene.Id);

        if (target == null)
        {
          return Result<HorizionGene>.Success(horizonGene);
        }
        horizonGene.Children = new List<HorizionTarget>();
        var horizonTarget = new HorizionTarget
        {
          Name = "Target",
          Attributes = {
                Id = target.Id,
                AccessionNumber = target.AccessionNumber,
                ProteinName = target.GeneName,
                BucketScore = target.Bucket
            }
        };
        horizonGene.Children.Add(horizonTarget);


        /* Now lets check for screens */

        var screens = await _context.Screens.Where(s => s.TargetId == target.Id)
        .ToListAsync();

        if (screens == null)
        {
          return Result<HorizionGene>.Success(horizonGene);
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
                  AccessionNumber = screen.AccessionNumber,
                  ProteinName = screen.GeneName
              }
          };
          horizonTarget.Children.Add(horizionScreen);

          // Start nesting from here
          var fhas = await _context.Projects.Where(p => p.ScreenId == screen.Id).ToListAsync();
          if (fhas != null)
          {
             horizionScreen.Children = new List<HorizionFHA>();
            foreach (var fha in fhas)
            {
              var horizionFHA = new HorizionFHA
              {
                Name = "FHA",
                Attributes = {
                  Id = fha.Id,
                  AccessionNumber = fha.AccessionNo,
                  ProjectName = fha.ProjectName,
                  Status = fha.Status,
                 
                }
              };
              horizionScreen.Children.Add(horizionFHA);



            }
          }
        }


        return Result<HorizionGene>.Success(horizonGene);
      }
    }
  }
}