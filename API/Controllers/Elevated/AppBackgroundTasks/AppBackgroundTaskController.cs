using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.AppConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.AppBackgroundTasks
{
  public class AppTaskController : ApiControllerBaseElevated
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.AppBackgroundTasks.List.Query { }));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(Guid Id)
    {
      return HandleResult(await Mediator.Send(new Application.AppBackgroundTasks.Read.Query { Id = Id }));
    }

  }
}