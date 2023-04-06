using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.Organisms
{
  public class OrganismController : ApiControllerBaseElevated
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.Organisms.List.Query { }));
    }
    [HttpPost]
    public async Task<IActionResult> Create(Organism newOrganism)
    {
      return HandleResult(await Mediator.Send(new Application.Organisms.Create.Command { Organism = newOrganism }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Edit(Guid id, Organism editedOrganism)
    {
      editedOrganism.Id = id;
      return HandleResult(await Mediator.Send(new Application.Organisms.Edit.Command { Organism = editedOrganism }));
    }


  }
}