using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General.Organisms
{
  public class OrganismController : ApiControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.Organisms.List.Query { }));
    }
  }
}