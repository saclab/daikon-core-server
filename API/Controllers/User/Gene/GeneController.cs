using System;
using System.Threading.Tasks;
using Application.Genes.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  // [Authorize(Policy = "RequireUserRole")]
  public class GeneController : User.BaseApiController
  {

    [HttpGet]
    public async Task<IActionResult> ListActivities()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Details.Query { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Gene gene)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Create.Command { Gene = gene }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Gene gene)
    {
      gene.Id = id;
      return HandleResult(await Mediator.Send(new Application.Genes.Edit.Command { Gene = gene }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {

      return HandleResult(await Mediator.Send(new Application.Genes.Delete.Command { Id = id }));
    }

    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetHistory(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.History.Query { Id = id }));
    }

    [HttpPost("{id}/promote")]
    public async Task<IActionResult> PromoteActivity(Guid id, GenePromotionQuestionaire genePromotionQuestionaire)
    {
      genePromotionQuestionaire.GeneID = id;
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Request.Command { GenePromotionQuestionaireAnswers = genePromotionQuestionaire }));
    }

    [HttpGet("{id}/promote")]
    public async Task<IActionResult> FetchPromoteQuestionaire(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Details.Query { Id = id }));
    }

  }
}