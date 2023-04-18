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
  public class NameValidator
  {
    public class Query : IRequest<Result<String>>
    {
      public string TargetName { get; set; }
      public Guid StrainId { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Query, Result<String>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;

      }

      public async Task<Result<String>> Handle(Query request, CancellationToken cancellationToken)
      {

        var validateNameTarget = await _context.Targets
        .FirstOrDefaultAsync(q => (
            q.Name == request.TargetName && q.StrainId == request.StrainId));

        if (validateNameTarget != null) return Result<String>.Success("TargetExists");

        var validateNamePromotionReq = await _context.GenePromotionRequests
        .FirstOrDefaultAsync(q => (
            q.TargetName == request.TargetName && q.StrainId == request.StrainId));

        if (validateNamePromotionReq != null) return Result<String>.Success("PromotionRequestExists");

        return Result<String>.Success("Valid");

      }
    }
  }
}