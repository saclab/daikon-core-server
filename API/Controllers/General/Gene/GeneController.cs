using System;
using System.Threading.Tasks;
using Application.Genes.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  // [Authorize(Policy = "RequireUserRole")]
  public class GeneController : ApiControllerBase
  {

    [HttpGet]
    public async Task<IActionResult> List()
    {
      return HandleResult(await Mediator.Send(new Application.Genes.List.Query()));
    }

    [HttpGet("strain/{strainId}")]
    public async Task<IActionResult> ListStrainFilter(Guid strainId)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.List.Query { StrainFilter = strainId }));
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
    public async Task<IActionResult> EditActivity(Guid id, GenePublicEditDTO genePublicEditDTO)
    {
      genePublicEditDTO.Id = id;
      return HandleResult(await Mediator.Send(new Application.Genes.Edit.Command { GenePublicEditDTO = genePublicEditDTO }));
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

    [HttpPost("promotionrequest/{targetName}")]
    public async Task<IActionResult> PromoteActivity(string targetName, GenePromotionRequest genePromotionRequest)
    {
      genePromotionRequest.TargetName = targetName;
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Request.Command { GenePromotionRequest = genePromotionRequest }));
    }

    [HttpGet("{id}/promotionrequest")]
    public async Task<IActionResult> FetchPromoteQuestionaire(String targetName)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.Details.Query { TargetName = targetName }));
    }

    [HttpGet("validate-new-target-name/{strainId}/{targetName}/")]
    public async Task<IActionResult> ValidateNewTargetName(Guid strainId, String targetName)
    {
      return HandleResult(await Mediator.Send(new Application.Genes.Promotion.NameValidator.Query { StrainId = strainId, TargetName = targetName }));
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

    [HttpPost("{geneId}/proteinproduction")]
    public async Task<IActionResult> AddProteinProduction(Guid geneId, GeneProteinProduction geneProteinProduction)
    {
      geneProteinProduction.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.ProteinProduction.Add.Command { GeneProteinProduction = geneProteinProduction }));
    }

    [HttpPost("{geneId}/proteinproduction/{id}")]
    public async Task<IActionResult> EditProteinProduction(Guid geneId, Guid id, GeneProteinProduction geneProteinProduction)
    {
      geneProteinProduction.Id = id;
      geneProteinProduction.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.ProteinProduction.Edit.Command { GeneProteinProduction = geneProteinProduction }));
    }

    [HttpPost("{geneId}/proteinactivityassay")]
    public async Task<IActionResult> AddGeneProteinActivityAssay(Guid geneId, GeneProteinActivityAssay geneProteinActivityAssay)
    {
      geneProteinActivityAssay.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.ProteinActivityAssay.Add.Command { GeneProteinActivityAssay = geneProteinActivityAssay }));
    }

    [HttpPost("{geneId}/proteinactivityassay/{id}")]
    public async Task<IActionResult> EditGeneProteinActivityAssay(Guid geneId, Guid id, GeneProteinActivityAssay geneProteinActivityAssay)
    {
      geneProteinActivityAssay.Id = id;
      geneProteinActivityAssay.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.ProteinActivityAssay.Edit.Command { GeneProteinActivityAssay = geneProteinActivityAssay }));
    }

    [HttpPost("{geneId}/crispristrain")]
    public async Task<IActionResult> AddGeneCRISPRiStrain(Guid geneId, GeneCRISPRiStrain geneCRISPRiStrain)
    {
      geneCRISPRiStrain.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.CRISPRiStrain.Add.Command { GeneCRISPRiStrain = geneCRISPRiStrain }));
    }

    [HttpPost("{geneId}/crispristrain/{id}")]
    public async Task<IActionResult> EditGeneCRISPRiStrain(Guid geneId, Guid id, GeneCRISPRiStrain geneCRISPRiStrain)
    {
      geneCRISPRiStrain.Id = id;
      geneCRISPRiStrain.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.CRISPRiStrain.Edit.Command { GeneCRISPRiStrain = geneCRISPRiStrain }));
    }

    [HttpPost("{geneId}/resistancemutation")]
    public async Task<IActionResult> AddGeneResistanceMutation(Guid geneId, GeneResistanceMutation geneResistanceMutation)
    {
      geneResistanceMutation.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.ResistanceMutation.Add.Command { GeneResistanceMutation = geneResistanceMutation }));
    }

    [HttpPost("{geneId}/resistancemutation/{id}")]
    public async Task<IActionResult> EditGeneResistanceMutation(Guid geneId, Guid id, GeneResistanceMutation geneResistanceMutation)
    {
      geneResistanceMutation.Id = id;
      geneResistanceMutation.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.ResistanceMutation.Edit.Command { GeneResistanceMutation = geneResistanceMutation }));
    }

    [HttpPost("{geneId}/unpublishedstructures")]
    public async Task<IActionResult> AddGeneUnpublishedStructures(Guid geneId, GeneUnpublishedStructures geneUnpublishedStructures)
    {
      geneUnpublishedStructures.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.UnpublishedStructures.Add.Command { GeneUnpublishedStructures = geneUnpublishedStructures }));
    }

    [HttpPost("{geneId}/unpublishedstructures/{id}")]
    public async Task<IActionResult> EditGeneUnpublishedStructures(Guid geneId, Guid id, GeneUnpublishedStructures geneUnpublishedStructures)
    {
      geneUnpublishedStructures.Id = id;
      geneUnpublishedStructures.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.UnpublishedStructures.Edit.Command { GeneUnpublishedStructures = geneUnpublishedStructures }));
    }

    [HttpPost("{geneId}/vulnerability")]
    public async Task<IActionResult> AddGeneVulnerability(Guid geneId, GeneVulnerability geneVulnerability)
    {
      geneVulnerability.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.Vulnerability.Add.Command { GeneVulnerability = geneVulnerability }));
    }

    [HttpPost("{geneId}/vulnerability/{id}")]
    public async Task<IActionResult> EditGeneVulnerability(Guid geneId, Guid id, GeneVulnerability geneVulnerability)
    {
      geneVulnerability.Id = id;
      geneVulnerability.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.Vulnerability.Edit.Command { GeneVulnerability = geneVulnerability }));
    }


    [HttpPost("{geneId}/hypomorph")]
    public async Task<IActionResult> AddHypomorph(Guid geneId, GeneHypomorph geneHypomorph)
    {
      geneHypomorph.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.Hypomorph.Add.Command { GeneHypomorph = geneHypomorph }));
    }

    [HttpPost("{geneId}/hypomorph/{id}")]
    public async Task<IActionResult> EditHypomorph(Guid geneId, Guid id, GeneHypomorph geneHypomorph)
    {
      geneHypomorph.Id = id;
      geneHypomorph.GeneId = geneId;
      return HandleResult(await Mediator.Send(new Application.Genes.Hypomorph.Edit.Command { GeneHypomorph = geneHypomorph }));
    }




  }
}