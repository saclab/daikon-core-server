using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens
{
  public class Create
  {
    public class Command : IRequest<Result<Screen>>
    {
      public Screen NewScreen { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Screen>>
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
      public async Task<Result<Screen>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid ScreenGid = Guid.NewGuid();


        var baseTarget = await _context.Targets.FirstOrDefaultAsync
            (t => t.Id == request.NewScreen.TargetId);

        /*chek if gene id is correct*/
        if (baseTarget == null)
        {
          return Result<Screen>.Failure("Invalid Target ID");
        }

        /*check if screen exists already */
        // var testTarget = await _context.Targets.FirstOrDefaultAsync(
        //    t => t.GeneId == request.GenePromotionQuestionaireAnswers.GeneID
        // );
        // if(testTarget!=null) {
        //   return Result<Target>.Failure("Target already exists");
        // }




        var ScreenToCreate = new Screen
        {
          Id = ScreenGid,
          BaseTarget = baseTarget,
          TargetId = baseTarget.Id,
          AccessionNumber = baseTarget.AccessionNumber,
          GeneName = baseTarget.GeneName,

          Status = "New",
          Library = request.NewScreen.Library,
          Scientist = _userAccessor.GetUsername(),
          StartDate = request.NewScreen.StartDate,
          EndDate = request.NewScreen.EndDate,
          Method = request.NewScreen.Method,
          Protocol = request.NewScreen.Protocol,
          Comment = request.NewScreen.Comment,
          Hits = new List<Hit>()
        };

        _context.Screens.Add(ScreenToCreate);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Screen>.Failure("Failed to create screen");
        return Result<Screen>.Success(ScreenToCreate);

      }


    }
  }
}