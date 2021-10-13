using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens.ScreenSequences
{
  public class Create
  {
    public class Command : IRequest<Result<ScreenSequence>>
    {
      public ScreenSequence NewScreenSequence { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<ScreenSequence>>
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
      public async Task<Result<ScreenSequence>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid ScreenSequenceGid = Guid.NewGuid();


        var baseScreen = await _context.Screens.FirstOrDefaultAsync
            (s => s.Id == request.NewScreenSequence.ScreenId);

        /*chek if gene id is correct*/
        if (baseScreen == null)
        {
          return Result<ScreenSequence>.Failure("Invalid Screen ID");
        }

        /*check if screen exists already */
        // var testTarget = await _context.Targets.FirstOrDefaultAsync(
        //    t => t.GeneId == request.GenePromotionQuestionaireAnswers.GeneID
        // );
        // if(testTarget!=null) {
        //   return Result<Target>.Failure("Target already exists");
        // }




        var ScreenSequenceToCreate = new ScreenSequence
        {
          Id = ScreenSequenceGid,
          ScreenId = request.NewScreenSequence.ScreenId,
          AccessionNumber = baseScreen.AccessionNumber,
          Method = request.NewScreenSequence.Method,
          Protocol = request.NewScreenSequence.Protocol,
          Library = request.NewScreenSequence.Library,
          Scientist = request.NewScreenSequence.Scientist,
          StartDate = request.NewScreenSequence.StartDate,
          EndDate = request.NewScreenSequence.EndDate,
          UnverifiedHitCount = request.NewScreenSequence.UnverifiedHitCount
        };




        _context.ScreenSequences.Add(ScreenSequenceToCreate);
        baseScreen.ScreenSequences.Add(ScreenSequenceToCreate);




        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<ScreenSequence>.Failure("Failed to create Screen Sequence");
        return Result<ScreenSequence>.Success(ScreenSequenceToCreate);

      }


    }
  }
}