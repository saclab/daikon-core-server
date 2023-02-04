using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.Promotion;
using Application.Interfaces;
using Application.Targets.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Targets
{
  public class EditTargetPromotionData
  {
    public class Command : IRequest<Result<Target>>
    {
      public List<TargetPromotionDataDTO> TargetPromotionDataDTOs { get; set; }
      public Guid TargetId { get; set; }
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

      public Handler(
          DataContext context,
          IMapper mapper,
          IUserAccessor userAccessor
      )
      {
        _userAccessor = userAccessor;
        _mapper = mapper;
        _context = context;
      }

      public async Task<Result<Target>>
      Handle(Command request, CancellationToken cancellationToken)
      {
        var targetToEdit =
            await _context
                .Targets
                .Include(t => t.TargetScorecard)
                .ThenInclude(t => t.TargetScoreCardValues)
                .FirstOrDefaultAsync(t =>
                    t.Id == request.TargetId);

        if (targetToEdit == null) return null;

        List<Guid> existingQuestionIds = targetToEdit.TargetScorecard.TargetScoreCardValues.Select(v => v.QuestionId).ToList();



        foreach (var targetPromotionDataDTO in request.TargetPromotionDataDTOs)
        {
          // check if scorecard exists
          if (existingQuestionIds.Contains(targetPromotionDataDTO.QuestionId))
          {
            // check if answer or description are different
            var fromOriginalTarget = targetToEdit.TargetScorecard.TargetScoreCardValues.Find(v => v.QuestionId == targetPromotionDataDTO.QuestionId);
            if (fromOriginalTarget.Answer != targetPromotionDataDTO.Answer || fromOriginalTarget.Description != targetPromotionDataDTO.Description)
            {
              // Modify the answer
              var targetScoreCardToEdit = await _context.TargetScoreCardValues.FirstOrDefaultAsync(v => v.Id == fromOriginalTarget.Id);
              targetScoreCardToEdit.Answer = targetPromotionDataDTO.Answer;
              targetScoreCardToEdit.Description = targetPromotionDataDTO.Description;
              targetScoreCardToEdit.AnswerdBy = _userAccessor.GetUsername();
            }
          }
          else
          {
            // check if it is a valid question and create a score card entry
            var questionToAdd = await _context.Questions.FirstOrDefaultAsync(q => q.Id == targetPromotionDataDTO.QuestionId);
            if (questionToAdd != null)
            {
              Guid targetScoreCardValueGid = Guid.NewGuid();
              var targetScoreCardValue = new TargetScoreCardValue
              {
                Id = targetScoreCardValueGid,
                TargetScorecardId = targetToEdit.TargetScorecard.Id,
                TargetName = targetToEdit.Name,
                Question = questionToAdd,
                QuestionId = questionToAdd.Id,
                QuestionIdentification = questionToAdd.Identification,
                QuestionModule = questionToAdd.Module,
                QuestionSubModule = questionToAdd.SubModule,
                Answer = targetPromotionDataDTO.Answer,
                Description = targetPromotionDataDTO.Description,
                AnswerdBy = _userAccessor.GetUsername()
              };

              targetToEdit.TargetScorecard.TargetScoreCardValues.Add(targetScoreCardValue);
              _context.TargetScoreCardValues.Add(targetScoreCardValue);
            }

          }

        }

        var success =
            await _context
                .SaveChangesAsync(_userAccessor.GetUsername()) >
            0;

        if (!success)
          return Result<Target>.Failure("Failed to edit Target ScoreCard");
        return Result<Target>.Success(targetToEdit);
      }
    }
  }
}
