using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using Application.Interfaces;
using Application.Targets.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

/* /!\ Warning Only for Simple Proteins */
namespace Application.Targets
{
  public class ImportComplex
  {
    public class Command : IRequest<Result<Target>>
    {
      public TargetImportDTO TargetImportDTO { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Target>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
      }
      public async Task<Result<Target>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid TargetGid = Guid.NewGuid();
        Guid TargetScorecardGid = Guid.NewGuid();


        var geneGroupToPromote = await _context.GeneGroups
                .Include(g => g.Genes)
                .ThenInclude(g => g.Gene)
                .FirstOrDefaultAsync
                (g => g.Name == request.TargetImportDTO.TargetName);

        /*chek if gene group exists*/
        if (geneGroupToPromote == null)
        {
          return Result<Target>.Failure("Invalid Gene Group");
        }

        /*check if target exists already */
        var testTarget = await _context.Targets.FirstOrDefaultAsync(
           t => t.Name == request.TargetImportDTO.TargetName
        );
        if (testTarget != null)
        {
          return Result<Target>.Failure("Target already exists");
        }

        var targetGenes = new List<TargetGene>();

        foreach (var geneGroupGene in geneGroupToPromote.Genes)
        {

          var targetGeneToAdd = new TargetGene()
          {
            Id = new Guid(),
            TargetId = TargetGid,
            GeneId = geneGroupGene.GeneId,
            Gene = geneGroupGene.Gene,
            AccessionNumber = geneGroupGene.Gene.AccessionNumber
          };
          _context.TargetGenes.Add(targetGeneToAdd);
          targetGenes.Add(targetGeneToAdd);
        }


        var TargetToCreate = new Target
        {
          Id = TargetGid,
          Name = request.TargetImportDTO.TargetName,
          Type = "protein-complex",
          TargetGenes = targetGenes,
          Bucket = request.TargetImportDTO.Bucket,
          ImpactScore = request.TargetImportDTO.ImpactScore,
          ImpactComplete = request.TargetImportDTO.ImpactComplete,
          LikeScore = request.TargetImportDTO.LikeScore,
          LikeComplete = request.TargetImportDTO.LikeComplete,
          ScreeningScore = request.TargetImportDTO.ScreeningScore,
          ScreeningComplete = request.TargetImportDTO.ScreeningComplete,
          StructureScore = request.TargetImportDTO.StructureScore,
          StructureComplete = request.TargetImportDTO.StructureComplete,
          VulnerabilityRatio = request.TargetImportDTO.VulnerabilityRatio,
          VulnerabilityRank = request.TargetImportDTO.VulnerabilityRank,
          HTSFeasibility = request.TargetImportDTO.HTSFeasibility,
          SBDFeasibility = request.TargetImportDTO.SBDFeasibility,
          Progressibility = request.TargetImportDTO.Progressibility,
          Safety = request.TargetImportDTO.Safety,

          TargetScorecard = new TargetScorecard
          {
            Id = TargetScorecardGid,
            TargetID = TargetGid,
            TargetName = request.TargetImportDTO.TargetName,
            TargetScoreCardValues = new List<TargetScoreCardValue>()
          }
        };

        foreach (var answer in request.TargetImportDTO.GenePromotionRequestValues)
        {
          Guid targetScoreCardValueGid = Guid.NewGuid();
          var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == answer.QuestionId);
          var targetScoreCardValue = new TargetScoreCardValue
          {
            Id = targetScoreCardValueGid,
            TargetScorecardId = TargetScorecardGid,
            TargetName = request.TargetImportDTO.TargetName,
            Question = question,
            QuestionId = question.Id,
            QuestionIdentification = question.Identification,
            QuestionModule = question.Module,
            QuestionSubModule = question.SubModule,
            Answer = answer.Answer,
            Description = answer.Description,
            AnswerdBy = answer.AnswerdBy
          };
          TargetToCreate.TargetScorecard.TargetScoreCardValues.Add(targetScoreCardValue);
          _context.TargetScoreCardValues.Add(targetScoreCardValue);
        }

        _context.TargetScorecards.Add(TargetToCreate.TargetScorecard);
        _context.Targets.Add(TargetToCreate);

        // if a request exists change its status from submitted to promoted

        var genePromotionReq = await _context.GenePromotionRequests.FirstOrDefaultAsync
            (g => g.TargetName == request.TargetImportDTO.TargetName);
        if (genePromotionReq != null)
        {
          genePromotionReq.GenePromotionRequestStatus = "Promoted";
        }

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Target>.Failure("Failed to create Target");
        return Result<Target>.Success(TargetToCreate);

      }


    }
  }
}