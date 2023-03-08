using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataView.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DataView.Compounds
{
  public class DetailView
  {

    public class Query : IRequest<Result<DetailViewDTO>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<DetailViewDTO>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;

      }
      public async Task<Result<DetailViewDTO>> Handle(Query request, CancellationToken cancellationToken)
      {

        var detailedCompound = new DetailViewDTO();
        var compound = await _context.Compounds.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (compound == null) return Result<DetailViewDTO>.Failure("Invalid Gene GUID");

        detailedCompound.Id = compound.Id;
        detailedCompound.ExternalCompoundIds = compound.ExternalCompoundIds;
        detailedCompound.Smiles = compound.Smile;
        detailedCompound.MolWeight = compound.MolWeight;
        detailedCompound.MolArea = compound.MolArea;
        detailedCompound.CreatedAt = compound.CreatedAt;


        // find all projects that have lists this compound as primary structure
        detailedCompound.ProjectsWithPrimaryStructure = await _context.Projects.Where(p => p.RepresentationStructureId == compound.Id).ToListAsync();

        // find all projects that have lists this compound as secondary structure
        var projectsWithSecondaryStructure = await _context.ProjectBaseHits.Include(pb => pb.BaseHit).Where(h => h.BaseHit.CompoundId == compound.Id).ToListAsync();
        detailedCompound.ProjectsWithBaseHits = new List<Project>();
        foreach (var projectWithSecondaryStructure in projectsWithSecondaryStructure)
        {
          var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectWithSecondaryStructure.ProjectId);
          if (project != null)
          {
            detailedCompound.ProjectsWithBaseHits.Add(project);
          }
        }

        // find all projects that have lists this compound in compound evolution
        var projectsWithCompoundEvolution = await _context.ProjectCompoundEvolutions.Where(h => h.CompoundId == compound.Id).ToListAsync();
        detailedCompound.ProjectsWithCompoundEvolution = new List<Project>();
        foreach (var projectWithCompoundEvolution in projectsWithCompoundEvolution)
        {
          var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectWithCompoundEvolution.ProjectId);
          if (project != null)
          {
            detailedCompound.ProjectsWithCompoundEvolution.Add(project);
          }
        }



        // find all hits that have this compound.
        var hitsWithCompoundId = await _context.Hits.Where(h => h.CompoundId == compound.Id).ToListAsync();

        // find all screens with these hits
        var screensWithHits = await _context.Screens.Include(s => s.ValidatedHits).Where(h => h.ValidatedHits.Any(vh => vh.CompoundId == compound.Id)).ToListAsync();
        detailedCompound.Screen = screensWithHits;

        return Result<DetailViewDTO>.Success(detailedCompound);
      }

    }
  }
}