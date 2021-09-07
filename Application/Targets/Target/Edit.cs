using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Targets
{
  public class EditTarget
  {
    public class Command : IRequest<Result<Target>>
    {
      public Target ModifiedTarget { get; set; }
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
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _userAccessor = userAccessor;
        _mapper = mapper;
        _context = context;
      }
      public async Task<Result<Target>> Handle(Command request, CancellationToken cancellationToken)
      {

        var targetToEdit = await _context.Targets
        .Include(t => t.TargetScorecard)
        .ThenInclude(s => s.TargetScoreCardValues)
        .FirstOrDefaultAsync(t => t.Id == request.ModifiedTarget.Id);


        if (targetToEdit == null) return null;

        targetToEdit.HTSFeasibility = request.ModifiedTarget.HTSFeasibility;
        targetToEdit.SBDFeasibility = request.ModifiedTarget.SBDFeasibility;
        targetToEdit.Progressibility = request.ModifiedTarget.Progressibility;
        targetToEdit.Saftey = request.ModifiedTarget.Saftey;

        if (request.ModifiedTarget.TargetScorecard != null)
        {
          foreach (var targetScoreCardValue in request.ModifiedTarget.TargetScorecard.TargetScoreCardValues)
          {
            var targetScoreCardValueToEdit = targetToEdit.TargetScorecard.TargetScoreCardValues.Find(t => t.Id == targetScoreCardValue.Id);
            targetScoreCardValueToEdit.Answer = targetScoreCardValue.Answer;
            targetScoreCardValueToEdit.Description = targetScoreCardValue.Description;
          }
        }


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;


        if (!success) return Result<Target>.Failure("Failed to edit genome");
        return Result<Target>.Success(targetToEdit);

      }



    }
  }
}