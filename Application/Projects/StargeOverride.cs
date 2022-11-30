using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Projects.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

/*
    This would overide the present  stage of the  projects.
    I/P - ProjectID 
    I/P - StageString -> Replace with this stage
*/
namespace Application.Projects
{
  public class StargeOverride
  {
    public class Command : IRequest<Result<Unit>>
    {
      public ProjectStageOverrideDTO projectStageOverrideDTO { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
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
      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {

        /* Fetch all the projects associated with the screenid that is being changed */
        var projectToEdit = await _context.Projects.FirstOrDefaultAsync
            (p => p.Id == request.projectStageOverrideDTO.ProjectId);

        if (request.projectStageOverrideDTO.StageString == ProjectStage.HA.Value)
        {
          projectToEdit.HAEnabled = true;
          projectToEdit.H2LEnabled = false;
          projectToEdit.LOEnabled = false;
          projectToEdit.SPEnabled = false;
          projectToEdit.INDEnabled = false;
          projectToEdit.ClinicalP1Enabled = false;
          projectToEdit.CurrentStage = ProjectStage.HA.Value;
        }
        else if (request.projectStageOverrideDTO.StageString == ProjectStage.H2L.Value)
        {
          projectToEdit.HAEnabled = true;
          projectToEdit.H2LEnabled = true;
          projectToEdit.LOEnabled = false;
          projectToEdit.SPEnabled = false;
          projectToEdit.INDEnabled = false;
          projectToEdit.ClinicalP1Enabled = false;
          projectToEdit.CurrentStage = ProjectStage.H2L.Value;
        }
        else if (request.projectStageOverrideDTO.StageString == ProjectStage.LO.Value)
        {
          projectToEdit.HAEnabled = true;
          projectToEdit.H2LEnabled = true;
          projectToEdit.LOEnabled = true;
          projectToEdit.SPEnabled = false;
          projectToEdit.INDEnabled = false;
          projectToEdit.ClinicalP1Enabled = false;

          projectToEdit.CurrentStage = ProjectStage.LO.Value;
        }
        else if (request.projectStageOverrideDTO.StageString == ProjectStage.SP.Value)
        {
          projectToEdit.HAEnabled = true;
          projectToEdit.H2LEnabled = true;
          projectToEdit.LOEnabled = true;
          projectToEdit.SPEnabled = true;
          projectToEdit.INDEnabled = false;
          projectToEdit.ClinicalP1Enabled = false;
          projectToEdit.CurrentStage = ProjectStage.SP.Value;
        }
        else if (request.projectStageOverrideDTO.StageString == ProjectStage.IND.Value)
        {
          projectToEdit.HAEnabled = true;
          projectToEdit.H2LEnabled = true;
          projectToEdit.LOEnabled = true;
          projectToEdit.SPEnabled = true;
          projectToEdit.INDEnabled = true;
          projectToEdit.ClinicalP1Enabled = false;
          projectToEdit.CurrentStage = ProjectStage.IND.Value;
        }
        else if (request.projectStageOverrideDTO.StageString == ProjectStage.P1.Value)
        {
          projectToEdit.HAEnabled = true;
          projectToEdit.H2LEnabled = true;
          projectToEdit.LOEnabled = true;
          projectToEdit.SPEnabled = true;
          projectToEdit.INDEnabled = true;
          projectToEdit.ClinicalP1Enabled = true;
          projectToEdit.CurrentStage = ProjectStage.P1.Value;
        }

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Unit>.Failure("Failed to override project stage");
        return Result<Unit>.Success(Unit.Value);

      }

    }
  }
}