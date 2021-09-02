using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Genes.Promotion
{
  public class Requests
  {
    public class Query : IRequest<Result<List<GenePromotionQuestionaire>>>
    {

    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Query, Result<List<GenePromotionQuestionaire>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;

      }

      public async Task<Result<List<GenePromotionQuestionaire>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genePromotionQuestionaires = new List<GenePromotionQuestionaire>();

        var geneSubmissionIDs = _context.GenePromotionRequests.Select(g => g.GeneID).Distinct();

        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
        foreach (var geneID in geneSubmissionIDs)
        {
          Console.WriteLine(geneID);
        }


        GenePromotionQuestionaire genePromotionQuestionaire = null;
        foreach (var geneID in geneSubmissionIDs)
        {
          genePromotionQuestionaire = new GenePromotionQuestionaire();
          genePromotionQuestionaire.GeneID = geneID;
          genePromotionQuestionaire.Answers = new Dictionary<string, Answer>();

          string status = "";
          string submittedBy = "";

          var questionaire = _context.GenePromotionRequests.Where(q => (
           q.GeneID == geneID &&
           q.QuestionModule == "TargetPromotionQuestions" &&
            q.Status == "Submitted" ));
          foreach (var item in questionaire)
          {
            genePromotionQuestionaire.Answers.Add(item.QuestionIdentification, new Answer()
            {
              AnswerValue = item.Answer,
              AnswerDescription = item.Description
            });
            status = item.Status;
            submittedBy = item.AnswerdBy;
          }
          genePromotionQuestionaire.Status = status;
          genePromotionQuestionaire.SubmittedBy = submittedBy;

          genePromotionQuestionaires.Add(genePromotionQuestionaire);
        }


        return Result<List<GenePromotionQuestionaire>>.Success(genePromotionQuestionaires);

      }
    }
  }
}