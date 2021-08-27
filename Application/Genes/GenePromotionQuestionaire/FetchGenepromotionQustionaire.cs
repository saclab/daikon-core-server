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

namespace Application.Genes
{
  public class FetchGenepromotionQustionaire
  {
    public class Query : IRequest<Result<GenePromotionQuestionaire>>
    {
      public Guid Id { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Query, Result<GenePromotionQuestionaire>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;

      }

      public async Task<Result<GenePromotionQuestionaire>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genePromotionQuestionaire = new GenePromotionQuestionaire();
        genePromotionQuestionaire.GeneID = request.Id;
        genePromotionQuestionaire.Answers = new Dictionary<string, Answer>();
        string status="";
        string submittedBy = "";

        var questionaire = _context.GenePromotionQuestionaireAnswers.Where(q => (
            q.GeneID == request.Id &&
            q.QuestionModule == "TargetPromotionQuestions"));
        foreach (var item in questionaire)
        {
          genePromotionQuestionaire.Answers.Add(item.QuestionIdentification, new Answer()
          {
            AnswerValue = item.Answer,
            AnswerDescription = item.Description
          });
          /*As per policy there would be one staus and only one people can submit a questionaire for a gene
            So fetching status and submitted by from one answer should be the same for all alnswers.
          */
          status = item.Status;
          submittedBy = item.AnswerdBy;
        }
        genePromotionQuestionaire.Status = status;
        genePromotionQuestionaire.SubmittedBy = submittedBy;



        return Result<GenePromotionQuestionaire>.Success(genePromotionQuestionaire);

      }
    }
  }
}