using System;
using System.Threading.Tasks;
using API.Controllers.Elevated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated
{

  public class GeneController : BaseApiController
  {
    [HttpGet("promotionrequests")]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Requests.Query()));
    }

    [HttpGet("groups")]
    public async Task<IActionResult> ListGroups()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Group.List.Query()));
    }

    [HttpGet("groups/{groupId}")]
    public async Task<IActionResult> DetailsGroups(Guid groupId)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Group.Details.Query { Id = groupId }));
    }

    [HttpPost("groups")]
    public async Task<IActionResult> CreateGroups(Domain.Models.GeneGroup geneGroup)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Group.Create.Command { GeneGroup = geneGroup }));
    }

    


  }
}