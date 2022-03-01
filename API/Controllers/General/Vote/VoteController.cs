using System;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class VoteController : BaseApiController
  {


    [HttpPost("{id}")]
    public async Task<IActionResult> RegisterVote(Guid id, Application.Votes.DTOs.RegisterVoteDTO registerVoteDTO)
    {
      registerVoteDTO.VoteId = id;
      return HandleResult(await Mediator.Send(new Application.Votes.Vote.Command { UserVote = registerVoteDTO }));
    }




  }
}