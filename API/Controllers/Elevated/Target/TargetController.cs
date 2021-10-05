using System;
using System.Threading.Tasks;
using Application.Genes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  public class TargetController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> CreateActivity(Domain.GenePromotionRequest genePromotionRequest)
    {
      return HandleResult(await Mediator.Send(new Application.Targets.Create.Command { GenePromotionRequest = genePromotionRequest }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Domain.Target target)
    {
      target.Id = id;
      return HandleResult(await Mediator.Send(new Application.Targets.Edit.Command { ModifiedTarget = target }));
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportActivity(Application.Targets.DTOs.TargetImportDTO TargetImportDTO)
    {
      return HandleResult(await Mediator.Send(new Application.Targets.Import.Command { TargetImportDTO = TargetImportDTO }));
    }
  }
}