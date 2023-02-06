using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class TargetController : ApiControllerBase
  {

    // List all
    [HttpGet]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new Application.Targets.List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Targets.Details.Query { Id = id }));
    }

    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetHistory(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Targets.History.Query { Id = id }));
    }

    [HttpPost("{id}/summary")]
    public async Task<IActionResult> EditSummaryActivity(Guid id, Application.Targets.DTOs.TargetSummaryDTO targetSummary)
    {
      targetSummary.Id = id;
      return HandleResult(await Mediator.Send(new Application.Targets.EditSummary.Command { ModifiedTarget = targetSummary }));
    }

    [HttpPost("{id}/promotion-info")]
    public async Task<IActionResult> EditPromotionInfo(Guid id, List<Application.Targets.DTOs.TargetPromotionDataDTO> targetPromotionDataDTOs)
    {

      return HandleResult(await Mediator.Send(new Application.Targets.EditTargetPromotionData.Command { TargetId = id, TargetPromotionDataDTOs = targetPromotionDataDTOs }));
    }

  }
}