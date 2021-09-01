using System.Threading.Tasks;
using API.Controllers.Elevated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  
  public class GeneController : BaseApiController
  {
    [HttpGet("promotionrequests")]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Requests.Query()));
    }
  }
}