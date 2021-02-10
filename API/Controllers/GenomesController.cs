using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Genomes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GenomesController : BaseController
  {
    [HttpGet]
    public async Task<ActionResult<List<Genome>>> List()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Genome>> Details(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<Genome>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<Genome>> Edit(Guid id, Edit.Command command)
    {
      command.Id = id;
      return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete(Guid id)
    {

      return await Mediator.Send(new Delete.Command { Id = id });
    }
  }
}