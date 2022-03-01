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
  public class Create
  {
    public class Command : IRequest<Result<Hit>>
    {
      public HitCSVDTO NewHit { get; set; }
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
        Guid HitGid = Guid.NewGuid();


        var baseScreen = await _context.Screens.FirstOrDefaultAsync
            (s => s.Id == request.NewHit.ScreenId);

        /*check if gene id is correct*/
        if (baseScreen == null)
        {
          return Result<Hit>.Failure("Invalid Screen ID");
        }


        /*check if screen exists already */
        // var testTarget = await _context.Targets.FirstOrDefaultAsync(
        //    t => t.GeneId == request.GenePromotionQuestionaireAnswers.GeneID
        // );
        // if(testTarget!=null) {
        //   return Result<Target>.Failure("Target already exists");
        // }

        Guid CompoundGid = Guid.NewGuid();

        var CompoundToCreate = new Compound
        {
          Id = CompoundGid,
          Smile = request.NewHit.Smile,
          SaccId = request.NewHit.SaccId,
          MolWeight = request.NewHit.MolWeight,
          MolArea = request.NewHit.MolArea
        };

        _context.Compounds.Add(CompoundToCreate);

        Guid VoteGid = Guid.NewGuid();

        var VoteToCreate = new Vote
        {
          Id = VoteGid,
          ElementId = HitGid,
          Positive = 0,
          Neutral = 0,
          Negative = 0,
          IsVotingAllowed = true
        };

        _context.Votes.Add(VoteToCreate);


        var HitToCreate = new Hit
        {
          Id = HitGid,
          ScreenId = request.NewHit.ScreenId,
          Library = request.NewHit.Library,
          Source = request.NewHit.Source,
          TargetName = baseScreen.TargetName,
          CompoundId = CompoundGid,
          Compound = CompoundToCreate,
          Method = request.NewHit.Method,
          MIC = request.NewHit.MIC,
          IC50 = request.NewHit.IC50,
          ClusterGroup = Int32.Parse(request.NewHit.ClusterGroup),
          Vote = VoteToCreate,
          VoteId = VoteGid
        };

        _context.Hits.Add(HitToCreate);

        baseScreen.ValidatedHits.Add(HitToCreate);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Hit>.Failure("Failed to create hit");
        return Result<Hit>.Success(HitToCreate);

      }


    }
  }
}