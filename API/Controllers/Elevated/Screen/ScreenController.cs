using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Screens.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  public class ScreenController : ApiControllerBaseElevated
  {
    [HttpPost("merge")]
    public async Task<IActionResult> Merge(ScreenMergeIdDTO screenMergeIdDTO)
    {
      return HandleResult(await
            Mediator.Send(
                new Application.Screens.Merge.ScreenMerge.Command
                {
                  ScreenMergeIdDTO = screenMergeIdDTO
                }));
    }

    [HttpPost("{id}/edit")]
    public async Task<IActionResult> Edit(Guid id, Screen modifiedScreen)
    {
      return HandleResult(await
            Mediator.Send(
                new Application.Screens.Edit.Command
                {
                  ModifiedScreen = modifiedScreen
                }));
    }

  }
}