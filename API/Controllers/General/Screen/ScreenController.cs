using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class ScreenController : ApiControllerBase
  {

    [HttpPost]
    [Authorize(Policy = "RequireScreenerRole")]
    public async Task<IActionResult> CreateScreen(Domain.Screen newScreen)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.Create.Command { NewScreen = newScreen }));
    }
    [HttpPost("phenotypic")]
    [Authorize(Policy = "RequireScreenerRole")]
    public async Task<IActionResult> CreatePhenotypicScreen(Domain.Screen newScreen)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.Phenotypic.Create.Command { NewScreen = newScreen }));
    }

    [HttpGet]
    public async Task<IActionResult> ListScreens()
    {
      return HandleResult(await Mediator.Send(new Application.Screens.List.Query()));
    }
    [HttpGet("phenotypic")]
    public async Task<IActionResult> ListPhenotypicScreens()
    {
      return HandleResult(await Mediator.Send(new Application.Screens.Phenotypic.List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Screens.Details.Query { Id = id }));
    }
  }
}