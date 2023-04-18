using System.Threading.Tasks;
using Application.BackgroundTasks.Genes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.Batch
{
  public class BatchController : ApiControllerBaseElevated
  {

    [HttpPost("gene-pool-sync")]
    public async Task<IActionResult> StartSync(GeneSyncInitDTO geneSyncInitDTO)
    {
      return HandleResult(await
            Mediator.Send(new Application.BackgroundTasks.Genes.StartPoolSync.Command { GeneSyncInitDTO = geneSyncInitDTO }));
    }

  }
}