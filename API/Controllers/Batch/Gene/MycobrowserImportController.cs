using System.Threading.Tasks;
using Application.Batch.Gene;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Batch.Gene
{
  [Route("api/batch/gene/[controller]")]
  public class MycobrowserImportController : BaseApiController
  {

    [HttpGet]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new MycobrowserPull.Command()));
    }

  }
}