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
  }
}