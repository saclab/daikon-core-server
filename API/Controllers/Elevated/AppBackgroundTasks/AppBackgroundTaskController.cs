using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.AppBackgroundTasks
{
  public class AppTaskController : ApiControllerBaseElevated
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.AppBackgroundTasksLog.List.Query { }));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(Guid Id)
    {
      return HandleResult(await Mediator.Send(new Application.AppBackgroundTasksLog.Read.Query { Id = Id }));
    }

  }
}