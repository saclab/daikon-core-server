using System;
using System.Threading.Tasks;
using Application.Genes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  public class TargetController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> CreateActivity(GenePromotionQuestionaire genePromotionQuestionaireAnswers)
    {
      return HandleResult(await Mediator.Send(new Application.Targets.Create.Command { GenePromotionQuestionaireAnswers = genePromotionQuestionaireAnswers }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Domain.Target target)
    {
      target.Id = id;
      return HandleResult(await Mediator.Send(new Application.Targets.Edit.Command { ModifiedTarget = target }));
    }
  }
}