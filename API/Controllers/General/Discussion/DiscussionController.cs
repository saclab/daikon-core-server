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

  }
}