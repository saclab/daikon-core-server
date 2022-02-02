using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class HorizionController : BaseApiController
  {
    [HttpGet("{targetName}")]
    public async Task<IActionResult> GenerateHorizion(String targetName)
    {
      return HandleResult(await Mediator.Send(new Application.General.Horizion.Generate.Query { TargetName = targetName }));
    }
  }
}