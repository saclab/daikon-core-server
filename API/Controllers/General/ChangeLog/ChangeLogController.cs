using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ChangeLogs.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General.ChangeLog
{
  public class ChangeLogController : ApiControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] string entity, [FromQuery] string property, [FromQuery] string key, [FromQuery] string keys)
    {
        var changeLogInputDTO = new ChangeLogInputDTO
        {
            Entity = entity,
            Property = property,
            Key = key,
            Keys = !string.IsNullOrEmpty(keys) ? keys.Split(',').ToList() : null
        };
      return HandleResult(await Mediator.Send(new Application.ChangeLogs.Generate.Query { ChangeLogInputDTO = changeLogInputDTO }));
    }
  }
}