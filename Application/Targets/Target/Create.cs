using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
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
      public GenePromotionQuestionaire GenePromotionQuestionaireAnswers { get; set; }
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
      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
      }
      public async Task<Result<Target>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid TargetGid = Guid.NewGuid();
        Guid TargetScorecardGid = Guid.NewGuid();

        var GeneToPromote = await _context.Genes.FirstOrDefaultAsync
            (g => g.Id == request.GenePromotionQuestionaireAnswers.GeneID);

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

        foreach (var answer in request.GenePromotionQuestionaireAnswers.Answers)
        {
          Guid targetScoreCardValueGid = Guid.NewGuid();
          var question = await _context.Questions.FirstOrDefaultAsync(q => q.Identification == answer.Key);
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
            Answer = answer.Value.AnswerValue,
            Description = answer.Value.AnswerDescription,
            AnswerdBy = request.GenePromotionQuestionaireAnswers.SubmittedBy
          };
          TargetToCreate.TargetScorecard.TargetScoreCardValues.Add(targetScoreCardValue);
          _context.TargetScoreCardValues.Add(targetScoreCardValue);
        }

        _context.TargetScorecards.Add(TargetToCreate.TargetScorecard);
        _context.Targets.Add(TargetToCreate);


        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Target>.Failure("Failed to create Genome");
        return Result<Target>.Success(TargetToCreate);



      }


    }
  }
}