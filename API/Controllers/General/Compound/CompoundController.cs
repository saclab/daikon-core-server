using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Compounds.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class CompoundController : ApiControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.Compounds.List.Query { }));
    }


    [HttpGet("by-external-id/{externalCompoundId}")]
    public async Task<IActionResult> GetCompoundByCId(string externalCompoundId)
    {
      return HandleResult(await Mediator.Send(new Application.Compounds.Details.ByID.Query { ExternalCompoundIds = externalCompoundId }));
    }

    [HttpGet("by-smile/{smile}")]
    public async Task<IActionResult> GetCompoundBySMILE(string smile)
    {
      return HandleResult(await Mediator.Send(new Application.Compounds.Details.BySMILE.Query { SMILE = smile }));
    }

    [HttpPost("{id}/edit")]
    public async Task<IActionResult> Edit(Guid id, CompoundEditDTO compound)
    {
      compound.Id = id;
      return HandleResult(await Mediator.Send(new Application.Compounds.Edit.BasicProperties.Command { EditedCompound = compound }));
    }

    [HttpPost("{id}/edit-external-id")]
    public async Task<IActionResult> EditExternalId(Guid id, Compound compound)
    {
      compound.Id = id;
      return HandleResult(await Mediator.Send(new Application.Compounds.Edit.ExternalId.Command { EditedCompound = compound }));
    }
  }
}