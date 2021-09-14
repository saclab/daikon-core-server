using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class ScreenController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> CreateScreen(Domain.Screen newScreen)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.Create.Command { NewScreen = newScreen }));
    }
  }
}