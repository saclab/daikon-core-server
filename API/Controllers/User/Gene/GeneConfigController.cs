using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class GeneConfigController : User.BaseApiController
  {
    [HttpGet("promote/questionaire")]
    public async Task<IActionResult> GetActivity()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Questionaire.Query { }));
    }
  }
}