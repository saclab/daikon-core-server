using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class GeneConfigController : ApiControllerBase
  {

    [HttpGet("promote/questionaire")]
    public async Task<IActionResult> GetActivity()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Questionaire.Query { }));
    }

    [HttpGet("groups/search-by-gene-id/{geneId}")]
    public async Task<IActionResult> SearchByGeneIdGroups(Guid geneId)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Group.SearchByGeneId.Query { GeneId = geneId }));
    }
  }
}