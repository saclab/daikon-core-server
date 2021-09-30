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

namespace Application.Genes.Promotion
{
  public class Request
  {
    public class Command : IRequest<Result<Unit>>
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
        var gene = await _context.Genes.FindAsync(request.GenePromotionRequest.GeneId);
        if (gene == null) return Result<Unit>.Failure("The Gene could not be found");

        var checkIfExists = _context.GenePromotionRequests.Where(q => (
            q.GeneId == request.GenePromotionRequest.GeneId));

        if (checkIfExists.Count() != 0) return Result<Unit>.Failure("There is already a submission");

        var newGenePromotionRequestId = new Guid();
        var newGenePromotionRequest = new GenePromotionRequest()
        {
          Id = newGenePromotionRequestId,
          Gene = gene,
          GeneId = gene.Id,
          GeneAccessionNumber = gene.AccessionNumber,
          GenePromotionRequestStatus = "Submitted",
          GenePromotionRequestValues = new List<GenePromotionRequestValue>()
        };

        foreach (GenePromotionRequestValue genePromotionRequestValue in request.GenePromotionRequest.GenePromotionRequestValues)
        {

          var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == genePromotionRequestValue.QuestionId);
          if (question != null)
          {
            var newGenePromotionRequestValue = new GenePromotionRequestValue()
            {
              Id = new Guid(),
              GenePromotionRequestId = newGenePromotionRequestId,
              Question = question,
              QuestionId = genePromotionRequestValue.QuestionId,
              Answer = genePromotionRequestValue.Answer,
              Description = genePromotionRequestValue.Description,
              AnswerdBy = _userAccessor.GetUsername()
            };

            newGenePromotionRequest.GenePromotionRequestValues.Add(newGenePromotionRequestValue);
            _context.GenePromotionRequestValues.Add(newGenePromotionRequestValue);
          }
        }
        _context.GenePromotionRequests.Add(newGenePromotionRequest);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Unit>.Failure("Failed to submit");
        return Result<Unit>.Success(Unit.Value);

      }
    }
  }
}