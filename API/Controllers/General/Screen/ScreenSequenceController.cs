using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class ScreenSequenceController : BaseApiController
  {
    [HttpPost("{screenId}")]
    public async Task<IActionResult> PostScreenSequemce(Guid screenId, ScreenSequence screenSequence)
    {
      screenSequence.ScreenId = screenId;
      return HandleResult(await Mediator.Send(new Application.Screens.ScreenSequences.Create.Command {  NewScreenSequence = screenSequence }));
    }
  }
}