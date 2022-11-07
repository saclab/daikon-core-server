using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class HitController : ApiControllerBase
  {

    [HttpGet("by-compound-id/{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.ValidatedHits.Details.ByCompoundUUID.Query { CompoundId = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateHit(Application.Screens.ValidatedHits.DTOs.HitCSVDTO newHit)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.ValidatedHits.Create.Command { NewHit = newHit }));
    }
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateHit(Application.Screens.ValidatedHits.DTOs.HitCSVDTO updatedHit)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.ValidatedHits.Update.Command { ModifiedHit = updatedHit }));
    }

  }
}