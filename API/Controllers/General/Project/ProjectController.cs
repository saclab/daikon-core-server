using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General.Project
{
  public class ProjectController : BaseApiController
  {
    [HttpGet]
    public async Task<IActionResult> ListProjects()
    {
      return HandleResult(await Mediator.Send(new Application.Projects.List.Query()));
    }
  }
}