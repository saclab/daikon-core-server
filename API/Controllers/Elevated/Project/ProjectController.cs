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

    /* Edit Project */

    [HttpPost("{id}")]
    public async Task<IActionResult> EditProject(Guid id, Application.Projects.DTOs.ProjectEditDTO project)
    {
      project.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.Edit.Command { project = project }));
    }

    /* Promote to h2l */
    [HttpPost("{id}/createH2L")]
    public async Task<IActionResult> CreateH2L(Guid id, Application.Projects.DTOs.H2LDTO h2LDetails)
    {
      h2LDetails.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateH2L.Command { H2LDetails = h2LDetails }));
    }

    /* Promote to lo */
    [HttpPost("{id}/createLO")]
    public async Task<IActionResult> CreateLO(Guid id, Application.Projects.DTOs.LODTO lODetails)
    {
      lODetails.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateLO.Command { LODetails = lODetails }));
    }

    /* Promote to SP */
    [HttpPost("{id}/createSP")]
    public async Task<IActionResult> CreateSP(Guid id, Application.Projects.DTOs.SPDTO sPDetails)
    {
      sPDetails.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateSP.Command { SPDetails = sPDetails }));
    }

    /* Promote to IND */
    [HttpPost("{id}/createIND")]
    public async Task<IActionResult> CreateIND(Guid id, Application.Projects.DTOs.INDDTO iNDDetails)
    {
      iNDDetails.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateIND.Command { INDDetails = iNDDetails }));
    }

    /* Promote to P1 */
    [HttpPost("{id}/createP1")]
    public async Task<IActionResult> CreateP1(Guid id, Application.Projects.DTOs.P1DTO p1Details)
    {
      p1Details.Id = id;
      return HandleResult(await Mediator.Send(new Application.Projects.CreateP1.Command { P1Details = p1Details }));
    }


    [HttpPost("{projectId}/compoundevolution")]
    public async Task<IActionResult> AddCompoundEvolution(Guid projectId, Application.Projects.DTOs.CompoundEvolutionAddDTO projectCompoundEvolution)
    {
      projectCompoundEvolution.ProjectId = projectId;
      return HandleResult(await Mediator.Send(new Application.Projects.CompoundEvolution.Add.Command { NewProjectCompoundEvolution = projectCompoundEvolution }));
    }


  }
}