using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class GeneConfigController : BaseApiController
  {
    [HttpGet("promote/questionaire")]
    public async Task<IActionResult> GetActivity()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Questionaire.Query { }));
    }
  }
}