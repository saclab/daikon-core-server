using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.AppConfigurations;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.AppConfigurations
{
  public class AppConfigurationController : ApiControllerBaseElevated
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.AppConfigurations.List.Query { }));
    }
    [HttpPost]
    public async Task<IActionResult> Create(AppConfiguration newAppConfiguration)
    {
      return HandleResult(await Mediator.Send(new Application.AppConfigurations.Create.Command { AppConfiguration = newAppConfiguration }));
    }
    [HttpPost("{key}")]
    public async Task<IActionResult> Edit(string key, AppConfiguration editedAppConfiguration)
    {
      editedAppConfiguration.Key = key;
      return HandleResult(await Mediator.Send(new Application.AppConfigurations.Update.Command { AppConfiguration = editedAppConfiguration }));
    }
    [HttpGet("{key}")]
    public async Task<IActionResult> Details(string key)
    {
      return HandleResult(await Mediator.Send(new Application.AppConfigurations.Read.Query { Key = key }));
    }

  }
}