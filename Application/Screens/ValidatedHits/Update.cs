using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Screens.ValidatedHits.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens.ValidatedHits
{
  public class Update
  {
    public class Command : IRequest<Result<Hit>>
    {
      public HitCSVDTO ModifiedHit { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Hit>>
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
      public async Task<Result<Hit>> Handle(Command request, CancellationToken cancellationToken)
      {

        var hit = await _context.Hits.FirstOrDefaultAsync(h => h.Id == request.ModifiedHit.Id);
        if (hit == null)
        {
          return Result<Hit>.Failure("Invalid Hit ID");
        }

        hit.Library = request.ModifiedHit.Library;
        hit.Source = request.ModifiedHit.Source;
        hit.MIC = request.ModifiedHit.MIC;
        hit.MICCondition = request.ModifiedHit.MICCondition;
        hit.IC50 = request.ModifiedHit.IC50;
        hit.ClusterGroup = Int32.Parse(request.ModifiedHit.ClusterGroup);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Hit>.Failure("Failed to modify hit");
        return Result<Hit>.Success(hit);

      }
    }
  }
}