using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Targets.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Targets
{
  public class EditSummary
  {
    public class Command : IRequest<Result<Target>>
    {
      public TargetSummaryDTO ModifiedTarget { get; set; }
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
                .FirstOrDefaultAsync(t =>
                    t.Id == request.ModifiedTarget.Id);

        if (targetToEdit == null) return null;

        targetToEdit.Background = request.ModifiedTarget.Background;
        targetToEdit.Enablement = request.ModifiedTarget.Enablement;
        targetToEdit.Strategy = request.ModifiedTarget.Strategy;
        targetToEdit.Challenges = request.ModifiedTarget.Challenges;

        var success =
            await _context
                .SaveChangesAsync(_userAccessor.GetUsername()) >
            0;

        if (!success)
          return Result<Target>.Failure("Failed to edit Target summary");
        return Result<Target>.Success(targetToEdit);
      }
    }
  }
}
