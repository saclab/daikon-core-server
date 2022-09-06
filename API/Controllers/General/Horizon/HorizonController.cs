using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class HorizonController : ApiControllerBase
  {

    [HttpGet("{entryPointName}")]
    public async Task<IActionResult> GenerateHorizon(String entryPointName)
    {
      return HandleResult(await Mediator.Send(new Application.General.Horizon.Generate.Query { EntryPointName = entryPointName }));
    }

    [HttpGet("by-accession/{accessionNumber}")]
    public async Task<IActionResult> GenerateHorizonByAccession(String accessionNumber)
    {
      return HandleResult(await Mediator.Send(new Application.General.Horizon.GenerateByAccession.Query { AccessionNumber = accessionNumber }));
    }
  }
}