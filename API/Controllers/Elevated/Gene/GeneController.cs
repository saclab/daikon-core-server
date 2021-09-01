using System.Threading.Tasks;
using API.Controllers.Elevated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin.Gene
{
  [Route("api/admin/[controller]")]
  public class GeneAdminController : BaseApiController
  {
    [HttpGet("submissions")]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Submissions.Query()));
    }
  }
}