using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class GeneConfigController : BaseApiController
  {
    [HttpGet("promotionquestions")]
    public async Task<IActionResult> GetActivity()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Config.TargetQuestionaire.List.Query { }));
    }
  }
}