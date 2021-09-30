using System;
using System.Collections.Generic;
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

        var GeneToPromote = await _context.Genes.FirstOrDefaultAsync
            (g => g.Id == request.GenePromotionRequest.GeneId);

        /*chek if gene id is correct*/
        if (GeneToPromote == null)
        {
          return Result<Target>.Failure("Invalid Gene ID");
        }

        /*check if target exists already */
        var testTarget = await _context.Targets.FirstOrDefaultAsync(
           t => t.GeneId == request.GenePromotionRequest.GeneId
        );
        if (testTarget != null)
        {
          return Result<Target>.Failure("Target already exists");
        }




        var TargetToCreate = new Target
        {
          Id = TargetGid,
          BaseGene = GeneToPromote,
          GeneId = GeneToPromote.Id,
          AccessionNumber = GeneToPromote.AccessionNumber,
          GeneName = GeneToPromote.GeneName,

          TargetScorecard = new TargetScorecard
          {
            Id = TargetScorecardGid,
            TargetID = TargetGid,
            TargetAccessionNumber = GeneToPromote.AccessionNumber,
            TargetScoreCardValues = new List<TargetScoreCardValue>()
          }
        };

        foreach (var answer in request.GenePromotionRequest.GenePromotionRequestValues)
        {
          Guid targetScoreCardValueGid = Guid.NewGuid();
          var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == answer.QuestionId);
          var targetScoreCardValue = new TargetScoreCardValue
          {
            Id = targetScoreCardValueGid,
            TargetScorecardId = TargetScorecardGid,
            TargetAccessionNumber = GeneToPromote.AccessionNumber,
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
            (g => g.GeneId == request.GenePromotionRequest.GeneId);
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