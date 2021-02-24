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
  public class GenomesController : BaseApiController
  {

    [HttpGet]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Genome genome)
    {
      return HandleResult(await Mediator.Send(new Create.Command { Genome = genome }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Genome genome)
    {
      genome.Id = id;
      return HandleResult(await Mediator.Send(new Edit.Command { Genome = genome }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {

      return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }

  }
}