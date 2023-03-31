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

        // check if compound exists already
        var compoundToAttach = new Compound();

        // TODO: Check by SMILE STRING when the app is ready for CHEM CARTRIDGE integration
        var testCompound = await _context.Compounds.FirstOrDefaultAsync(
           c => c.ExternalCompoundIds == request.NewHit.ExternalCompoundIds
        );
        if (testCompound != null)
        {
          compoundToAttach = testCompound;
          compoundToAttach.Id = testCompound.Id;
        }
        else
        {
          Guid CompoundGid = Guid.NewGuid();
          var CompoundToCreate = new Compound
          {
            Id = CompoundGid,
            Smile = request.NewHit.Smile,
            ExternalCompoundIds = request.NewHit.ExternalCompoundIds,
            MolWeight = request.NewHit.MolWeight,
            MolArea = request.NewHit.MolArea
          };
          _context.Compounds.Add(CompoundToCreate);

          compoundToAttach = CompoundToCreate;
          compoundToAttach.Id = CompoundGid;
        }


        Guid VoteGid = Guid.NewGuid();

        var VoteToCreate = new Vote
        {
          Id = VoteGid,
          ElementId = HitGid,
          Positive = 0,
          Neutral = 0,
          Negative = 0,
          IsVotingAllowed = true,
          CreatedAt = DateTime.UtcNow,
          CreatedBy = _userAccessor.GetUsername(),
        };


        _context.Votes.Add(VoteToCreate);


        var HitToCreate = new Hit
        {
          Id = HitGid,
          ScreenId = request.NewHit.ScreenId,
          Library = request.NewHit.Library,
          Source = request.NewHit.Source,
          TargetName = baseScreen.TargetName,
          CompoundId = compoundToAttach.Id,
          Compound = compoundToAttach,
          Method = request.NewHit.Method,
          MIC = request.NewHit.MIC,
          MICCondition = request.NewHit.MICCondition,
          IC50 = request.NewHit.IC50,
          ClusterGroup = request.NewHit.ClusterGroup,
          Vote = VoteToCreate,
          VoteId = VoteGid
        };

        HitToCreate.CreatedAt = DateTime.UtcNow;
        HitToCreate.CreatedBy = _userAccessor.GetUsername();

        _context.Hits.Add(HitToCreate);

        baseScreen.ValidatedHits.Add(HitToCreate);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Hit>.Failure("Failed to create hit");
        return Result<Hit>.Success(HitToCreate);

      }


    }
  }
}