using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Votes.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  public class VoteController : ApiControllerBaseElevated
  {

    [HttpPost("freeze")]
    public async Task<IActionResult> FreezeVote(List<Guid> VoteIds)
    {
      return HandleResult(await Mediator.Send(new Application.Votes.FreezeVoting.Command { VoteIds = VoteIds }));
    }

    [HttpPost("enable")]
    public async Task<IActionResult> EnableVote(List<Guid> VoteIds)
    {
      return HandleResult(await Mediator.Send(new Application.Votes.EnableVoting.Command { VoteIds = VoteIds }));
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportExisting(ImportVoteDTO importVote)
    {
      return HandleResult(await Mediator.Send(new Application.Votes.Imports.ImportExisting.Command { importVote = importVote }));
    }

  }
}