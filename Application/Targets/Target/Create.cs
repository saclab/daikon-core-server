using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Targets
{
  public class Create
  {
    public class Command : IRequest<Result<Target>>
    {
      public GenePromotionRequest GenePromotionRequest { get; set; }
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


        /* Check if target name already exists for the strain */
        var checkIfTargetExists = _context.Targets.Where(q => (
          q.Name == request.GenePromotionRequest.TargetName && q.StrainId == request.GenePromotionRequest.StrainId));

        if (checkIfTargetExists.Count() != 0) return Result<Target>.Failure("The intended target is already promoted");


        var TargetToCreate = new Target
        {
          Id = TargetGid,
          StrainId = request.GenePromotionRequest.StrainId,
          Name = request.GenePromotionRequest.TargetName,
          Type = request.GenePromotionRequest.TargetType,

          TargetGenes = new List<TargetGene>(),

          TargetScorecard = new TargetScorecard
          {
            Id = TargetScorecardGid,
            TargetID = TargetGid,
            TargetName = request.GenePromotionRequest.TargetName,
            TargetScoreCardValues = new List<TargetScoreCardValue>()
          }
        };

        TargetToCreate.CreatedAt = DateTime.UtcNow;
        TargetToCreate.CreatedBy = _userAccessor.GetUsername();

        foreach (var genePromotionRequestGene in request.GenePromotionRequest.GenePromtionRequestGenes)
        {
          var gene = await _context.Genes.FirstOrDefaultAsync(g => g.Id == genePromotionRequestGene.GeneId);
          if (gene == null)
          {
            return Result<Target>.Failure("Invalid Gene Id");
          }
          var targetGeneToAdd = new TargetGene()
          {
            Id = new Guid(),
            TargetId = TargetGid,
            GeneId = genePromotionRequestGene.GeneId,
            Gene = gene,
            AccessionNumber = gene.AccessionNumber

          };

          TargetToCreate.TargetGenes.Add(targetGeneToAdd);
          _context.TargetGenes.Add(targetGeneToAdd);
        }

        foreach (var answer in request.GenePromotionRequest.GenePromotionRequestValues)
        {
          Guid targetScoreCardValueGid = Guid.NewGuid();
          var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == answer.QuestionId);
          var targetScoreCardValue = new TargetScoreCardValue
          {
            Id = targetScoreCardValueGid,
            TargetScorecardId = TargetScorecardGid,
            TargetName = request.GenePromotionRequest.TargetName,
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
            (g => g.TargetName == request.GenePromotionRequest.TargetName);


        if (genePromotionReq != null)
        {
          genePromotionReq.GenePromotionRequestStatus = "Promoted";
        }

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Target>.Failure("Failed to create Genome");
        return Result<Target>.Success(TargetToCreate);



      }


    }
  }
}