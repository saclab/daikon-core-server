using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.Promotion
{
  public class Requests
  {
    public class Query : IRequest<Result<List<GenePromotionRequest>>>
    {

    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Query, Result<List<GenePromotionRequest>>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;

      }

      public async Task<Result<List<GenePromotionRequest>>> Handle(Query request, CancellationToken cancellationToken)
      {
        
        var genePromotionRequests = await _context.GenePromotionRequests
        .Include(p => p.GenePromtionRequestGenes)
        .Include(s => s.GenePromotionRequestValues)
        .ThenInclude(q => q.Question)
        .Where(r => r.GenePromotionRequestStatus == "Submitted").ToListAsync(cancellationToken);
        return Result<List<GenePromotionRequest>>.Success(genePromotionRequests);

      }
    }
  }
}