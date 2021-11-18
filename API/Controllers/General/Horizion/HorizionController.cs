using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class HorizionController : BaseApiController
  {
    [HttpGet("{accessionNo}")]
    public async Task<IActionResult> GenerateHorizion(String accessionNo)
    {
      return HandleResult(await Mediator.Send(new Application.General.Horizion.Generate.Query { AccessionNumber = accessionNo }));
    }
  }
}