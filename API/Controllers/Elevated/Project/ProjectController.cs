using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  public class ProjectController : BaseApiController
  {

    /* Create a new project with FHA Data */
    [HttpPost]
    public async Task<IActionResult> CreateProject(Application.Projects.DTOs.ProjectCreateDTO newProject)
    {
      return HandleResult(await Mediator.Send(new Application.Projects.CreateFHA.Command { NewProject = newProject }));
    }

    /* Promote to h2l */
    [HttpPost("{id}/createH2L")]
    public async Task<IActionResult> CreateH2L(Guid id, Application.Projects.DTOs.H2LDTO h2LDetails)
    {
      h2LDetails.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateH2L.Command { H2LDetails = h2LDetails }));
    }

    /* Promote to lo */
    [HttpPost("{id}/createH2L")]
    public async Task<IActionResult> CreateLO(Guid id, Application.Projects.DTOs.LODTO lODetails)
    {
      lODetails.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateLO.Command { LODetails = lODetails }));
    }


    [HttpPost("{projectId}/compoundevolution")]
    public async Task<IActionResult> AddCompoundEvolution(Guid projectId, Application.Projects.DTOs.CompoundEvolutionAddDTO projectCompoundEvolution)
    {
      projectCompoundEvolution.ProjectId = projectId;
      return HandleResult(await Mediator.Send(new Application.Projects.CompoundEvolution.Add.Command { NewProjectCompoundEvolution = projectCompoundEvolution }));
    }


  }
}