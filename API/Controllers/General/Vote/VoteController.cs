using System;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class VoteController : ApiControllerBase
  {

    [HttpPost("{id}")]
    [Authorize(Policy = "RequireVoterRole")]
    public async Task<IActionResult> RegisterVote(Guid id, Application.Votes.DTOs.RegisterVoteDTO registerVoteDTO)
    {
      registerVoteDTO.VoteId = id;
      return HandleResult(await Mediator.Send(new Application.Votes.Vote.Command { UserVote = registerVoteDTO }));
    }




  }
}