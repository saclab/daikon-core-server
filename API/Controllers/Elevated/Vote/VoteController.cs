using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{
  public class VoteController : BaseApiController
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

  }
}