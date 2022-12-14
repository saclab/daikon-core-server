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
  public class Details
  {
    public class Query : IRequest<Result<GenePromotionRequest>>
    {
      public string TargetName { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Query, Result<GenePromotionRequest>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;

      }

      public async Task<Result<GenePromotionRequest>> Handle(Query request, CancellationToken cancellationToken)
      {


        var genePromotionRequest = await _context.GenePromotionRequests
        .Include(s => s.GenePromotionRequestValues)
        .ThenInclude(q => q.Question)
        .FirstOrDefaultAsync(q => (
            q.TargetName == request.TargetName));
        return Result<GenePromotionRequest>.Success(genePromotionRequest);

      }
    }
  }
}