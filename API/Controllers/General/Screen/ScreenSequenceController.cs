using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class ScreenSequenceController : ApiControllerBase
  {

    [HttpPost("{screenId}")]
    [Authorize(Policy = "RequireScreenerRole")]
    public async Task<IActionResult> PostScreenSequence(Guid screenId, ScreenSequence screenSequence)
    {
      screenSequence.ScreenId = screenId;
      return HandleResult(await Mediator.Send(new Application.Screens.ScreenSequences.Create.Command { NewScreenSequence = screenSequence }));
    }

    [HttpPost("{screenId}/edit-sequence/{screenSequenceId}")]
    [Authorize(Policy = "RequireScreenerRole")]
    public async Task<IActionResult> EditScreenSequence(Guid screenId, Guid screenSequenceId, ScreenSequence screenSequence)
    {
      screenSequence.ScreenId = screenId;
      screenSequence.Id = screenSequenceId;
      return HandleResult(await Mediator.Send(new Application.Screens.ScreenSequences.Edit.Command { ScreenSequence = screenSequence }));
    }
  }
}