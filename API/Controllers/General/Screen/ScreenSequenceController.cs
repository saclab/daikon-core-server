using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class ScreenSequenceController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> PostScreenSequemce(ScreenSequence screenSequence)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.ScreenSequences.Create.Command {  NewScreenSequence = screenSequence }));
    }
  }
}