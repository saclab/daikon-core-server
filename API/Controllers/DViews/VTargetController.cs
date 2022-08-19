using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DView;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.DView
{
  public class VTargetController : ApiControllerBaseDView
  {
    [HttpGet("dash-view")]
    public async Task<IActionResult> DashView()
    {
      return HandleResult(await Mediator.Send(new DataView.TargetDash.Query()));
    }
  }
}