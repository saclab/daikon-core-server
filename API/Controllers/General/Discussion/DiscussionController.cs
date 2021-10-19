using System;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class DiscussionController : BaseApiController
  {
    [HttpGet("{reference}")]
    public async Task<IActionResult> GetDiscussion(string reference)
    {
      return HandleResult(await Mediator.Send(new Application.Discussions.Details.Query { Reference = reference }));
    }

    [HttpPost]
    public async Task<IActionResult> NewDiscussion(Discussion discussion)
    {
      return HandleResult(await Mediator.Send(new Application.Discussions.New.Command { Discussion = discussion }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditDiscussion(Guid id, Discussion discussion)
    {
      discussion.Id = id;
      return HandleResult(await Mediator.Send(new Application.Discussions.Edit.Command { Discussion = discussion }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiscussion(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Discussions.Delete.Command { Id = id }));
    }

    [HttpPost("{discussionId}/reply")]
    public async Task<IActionResult> NewReply(Guid discussionId, Reply reply)
    {
      reply.DiscussionId = discussionId;
      return HandleResult(await Mediator.Send(new Application.Discussions.Replies.New.Command { Reply = reply }));
    }

    [HttpPost("{discussionId}/reply/{id}")]
    public async Task<IActionResult> EditReply(Guid discussionId, Guid id, Reply reply)
    {
      reply.Id = id;
      reply.DiscussionId = discussionId;
      return HandleResult(await Mediator.Send(new Application.Discussions.Replies.Edit.Command { Reply = reply }));
    }

    [HttpDelete("{discussionId}/reply/{id}")]
    public async Task<IActionResult> DeleteReply(Guid discussionId, Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Discussions.Replies.Delete.Command { Id = id }));
    }


  }
}