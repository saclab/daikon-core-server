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

        Console.WriteLine("+++++++++++++++++++Application.Genes.Promotion");
        var checkIfTargetExists = _context.Targets.Where(q => (
           q.Name == request.GenePromotionRequest.TargetName && q.StrainId == request.GenePromotionRequest.StrainId));

        if (checkIfTargetExists.Count() != 0) return Result<Unit>.Failure("The intended target is already promoted");

        var checkIfSubmissionExists = _context.GenePromotionRequests.Where(q => (
            q.TargetName == request.GenePromotionRequest.TargetName && q.StrainId == request.GenePromotionRequest.StrainId));

        if (checkIfSubmissionExists.Count() != 0) return Result<Unit>.Failure("The intended target is already submitted for promotion and is pending review");

        var newGenePromotionRequestId = new Guid();


        var newGenePromotionRequest = new GenePromotionRequest()
        {
          Id = newGenePromotionRequestId,
          TargetName = request.GenePromotionRequest.TargetName,

          TargetType = request.GenePromotionRequest.TargetType,
          GenePromtionRequestGenes = new List<GenePromtionRequestGene>(),
          GenePromotionRequestStatus = "Submitted",
          GenePromotionRequestValues = new List<GenePromotionRequestValue>()
        };

        // Add strain ID

        var firstGeneId = request.GenePromotionRequest.GenePromtionRequestGenes.FirstOrDefault().GeneId;
        var firstGene = await _context.Genes.FirstOrDefaultAsync(g => g.Id == firstGeneId);
        if (firstGene != null)
        {
          newGenePromotionRequest.StrainId = firstGene.StrainId;
        }

        foreach (var gene in request.GenePromotionRequest.GenePromtionRequestGenes)
        {
          var geneToAdd = new GenePromtionRequestGene()
          {
            Id = new Guid(),
            GenePromotionRequestId = newGenePromotionRequestId,
            GeneId = gene.GeneId
          };

          newGenePromotionRequest.GenePromtionRequestGenes.Add(geneToAdd);
          _context.GenePromtionRequestGenes.Add(geneToAdd);

        }

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