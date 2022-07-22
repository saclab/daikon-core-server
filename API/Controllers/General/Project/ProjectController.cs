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
  }
}