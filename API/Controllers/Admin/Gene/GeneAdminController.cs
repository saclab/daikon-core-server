using System.Threading.Tasks;
using Application.Genes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin.Gene
{
  [Route("api/admin/[controller]")]
  public class GeneAdminController : BaseApiController
  {
    [HttpGet("promotions")]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new FetchGenePromotionSubmission.Query()));
    }
  }
}