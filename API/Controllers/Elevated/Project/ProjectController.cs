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
  }
}