using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DView;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.DView
{
  public class VCompoundController : ApiControllerBaseDView
  {
    [HttpGet("details/{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
      return HandleResult(await Mediator.Send(new DataView.Compounds.DetailView.Query { Id = id }));
    }
  }
}