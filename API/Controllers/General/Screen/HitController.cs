using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
    public class HitController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateHit(Domain.Hit newHit)
        {
            return HandleResult(await Mediator.Send(new Application.Screens.ValidatedHits.Create.Command { NewHit = newHit }));
        }
    }
}