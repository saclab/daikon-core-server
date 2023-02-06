using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General.Project
{
  public class ProjectController : ApiControllerBase
  {

    [HttpGet]
    public async Task<IActionResult> ListProjects()
    {
      return HandleResult(await Mediator.Send(new Application.Projects.List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Projects.Details.Query { Id = id }));
    }

    [HttpGet("{projectId}/compoundevolution")]
    public async Task<IActionResult> GetCompoundEvolution(Guid projectId)
    {
      return HandleResult(await Mediator.Send(new Application.Projects.CompoundEvolution.Details.Query { ProjectId = projectId }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> ModifyPriorityProbability(Guid id, Application.Projects.DTOs.ProjectPriorityProbabilityDTO projectPriorityProbability)
    {
      projectPriorityProbability.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.SetPriorityProbability.Command { projectPriorityProbabilityDTO = projectPriorityProbability }));
    }

    [HttpPost("{projectId}/compoundevolution")]
    public async Task<IActionResult> AddCompoundEvolution(Guid projectId, Application.Projects.DTOs.CompoundEvolutionDTO projectCompoundEvolution)
    {
      projectCompoundEvolution.ProjectId = projectId;
      return HandleResult(await Mediator.Send(new Application.Projects.CompoundEvolution.Add.Command { NewProjectCompoundEvolution = projectCompoundEvolution }));
    }

    [HttpPost("{projectId}/compoundevolution/{compoundEvolutionId}")]
    public async Task<IActionResult> EditCompoundEvolution(Guid projectId, Guid compoundEvolutionId, Application.Projects.DTOs.CompoundEvolutionDTO projectCompoundEvolution)
    {
      projectCompoundEvolution.ProjectId = projectId;
      projectCompoundEvolution.Id = compoundEvolutionId;

      return HandleResult(await Mediator.Send(new Application.Projects.CompoundEvolution.Edit.Command { EditedProjectCompoundEvolution = projectCompoundEvolution }));
    }


    [HttpPost("{projectId}/edit-supporting-org")]
    public async Task<IActionResult> EditSecondaryOrgs(Guid projectId, Application.Projects.DTOs.SupportingOrgDTO supportingOrgDTO)
    {
      supportingOrgDTO.ProjectId = projectId;
      return HandleResult(await Mediator.Send(new Application.Projects.EditSupportingOrgs.Command { supportingOrgDTO = supportingOrgDTO }));
    }
    [HttpPost("{projectId}/edit-predicted-dates")]
    public async Task<IActionResult> EditPredictedDates(Guid projectId, Application.Projects.DTOs.ProjectEditDTO projectEditDTO)
    {
      projectEditDTO.Id = projectId;
      return HandleResult(await Mediator.Send(new Application.Projects.EditPredictedDates.Command { project = projectEditDTO }));
    }

  }
}