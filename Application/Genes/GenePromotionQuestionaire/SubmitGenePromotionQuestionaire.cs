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
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes
{
  public class SubmitGenePromotionQuestionaire
  {
    public class Command : IRequest<Result<Unit>>
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

    public class Handler : IRequestHandler<Command, Result<Unit>>
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
      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var gene = await _context.Genes.FindAsync(request.GenePromotionQuestionaireAnswers.GeneID);
        if (gene == null) return Result<Unit>.Failure("The Gene could not be found");

        var checkIfExists = _context.GenePromotionQuestionaireAnswers.Where(q => (
            q.GeneID == request.GenePromotionQuestionaireAnswers.GeneID &&
            q.QuestionModule == "TargetPromotionQuestions"));

        if (checkIfExists.Count() != 0) return Result<Unit>.Failure("There is already a submission");

        foreach (KeyValuePair<string, Answer> kvp in request.GenePromotionQuestionaireAnswers.Answers)
        {

          var question = await _context.Questions.FirstOrDefaultAsync(q => q.Identification == kvp.Key);
          if (question != null)
          {
            var genePromotionQuestionaireAnswer = new GenePromotionQuestionaireAnswer()
            {
              Id = new Guid(),
              Gene = gene,
              GeneID = gene.Id,
              GeneAccessionNumber = gene.AccessionNumber,
              Status = "Submitted",
              Question = question,
              QuestionId = question.Id,
              QuestionIdentification = question.Identification,
              QuestionModule = question.Module,
              Answer = kvp.Value.AnswerValue,
              Description = kvp.Value.AnswerDescription,
              AnswerdBy = _userAccessor.GetUsername()
            };

            _context.GenePromotionQuestionaireAnswers.Add(genePromotionQuestionaireAnswer);

          }

        }

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Unit>.Failure("Failed to submit");
        return Result<Unit>.Success(Unit.Value);

      }
    }
  }
}