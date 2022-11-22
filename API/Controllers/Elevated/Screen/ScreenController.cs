using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.Screen
{
  public class ScreenController : ApiControllerBaseElevated
  {
    [HttpPost("merge")]
    public async Task<IActionResult> FreezeVote(Guid baseScreenID, Guid mergeScreenId)
    {
      return HandleResult(await
            Mediator.Send(
                new Application.Screens.Merge.ScreenMerge.Command
                {
                  BaseScreenID = baseScreenID,
                  MergeScreenID = mergeScreenId
                }));
    }

  }
}