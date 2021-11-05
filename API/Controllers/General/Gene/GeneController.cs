using System;
using System.Threading.Tasks;
using Application.Genes.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  // [Authorize(Policy = "RequireUserRole")]
  public class GeneController : BaseApiController
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

    [HttpGet("by-accession/{accessionNo}")]
    public async Task<IActionResult> GetGeneByAccessionNo(string accessionNo)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.DetailsFromAccessionNo.Query { AccessionNumber = accessionNo }));
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

    [HttpPost("{id}/promotionrequest")]
    public async Task<IActionResult> PromoteActivity(Guid id, GenePromotionRequest genePromotionRequest)
    {
      genePromotionRequest.GeneId = id;
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Request.Command { GenePromotionRequest = genePromotionRequest }));
    }

    [HttpGet("{id}/promotionrequest")]
    public async Task<IActionResult> FetchPromoteQuestionaire(Guid id)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Details.Query { GeneId = id }));
    }

    [HttpPost("{geneId}/essentiality")]
    public async Task<IActionResult> AddEssentiality(Guid geneId, GeneEssentiality geneEssentiality)
    {
      geneEssentiality.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.Essentiality.Add.Command { GeneEssentiality = geneEssentiality }));
    }

    [HttpPost("{geneId}/essentiality/{id}")]
    public async Task<IActionResult> EditEssentiality(Guid geneId, Guid id, GeneEssentiality geneEssentiality)
    {
      geneEssentiality.Id = id;
      geneEssentiality.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.Essentiality.Edit.Command { GeneEssentiality = geneEssentiality }));
    }

  }
}