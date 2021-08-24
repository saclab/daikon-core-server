using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Genes;
using Application.Genes.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  // [Authorize(Policy = "RequireUserRole")]
  public class GeneController : BaseApiController
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
    public async Task<IActionResult> CreateActivity(Gene gene)
    {
      return HandleResult(await Mediator.Send(new Create.Command { Gene = gene }));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Gene gene)
    {
      gene.Id = id;
      return HandleResult(await Mediator.Send(new Edit.Command {  Gene = gene }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {

      return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }

    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetHistory(Guid id)
    {
      return HandleResult(await Mediator.Send(new History.Query { Id = id }));
    }

    [HttpPost("{id}/promote")]
    public async Task<IActionResult> PromoteActivity(Guid id, GenePromotionQuestionaire genePromotionQuestionaire)
    {
      genePromotionQuestionaire.GeneID = id;
      return HandleResult(await Mediator.Send(new SubmitGenePromotionQuestionaire.Command {  GenePromotionQuestionaireAnswers = genePromotionQuestionaire }));
    }

    [HttpGet("{id}/promote")]
    public async Task<IActionResult> FetchPromoteQuestionaire(Guid id)
    {
      return HandleResult(await Mediator.Send(new FetchGenepromotionQustionaire.Query { Id = id }));
    }

  }
}