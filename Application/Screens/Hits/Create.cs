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

namespace Application.Screens.Hits
{
    public class Create
    {
        public class Command : IRequest<Result<Hit>>
        {
            public Hit NewHit { get; set; }
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

                /*chek if gene id is correct*/
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




                var HitToCreate = new Hit
                {
                    Id = HitGid,
                    ScreenId = request.NewHit.ScreenId,
                    Library = request.NewHit.Library,
                    CompoundId = request.NewHit.CompoundId,
                    EnzymeActivity = request.NewHit.EnzymeActivity,
                    Method = request.NewHit.Method,
                    MIC = request.NewHit.MIC,
                    Structure = request.NewHit.Structure,
                    ClusterGroup = request.NewHit.ClusterGroup,
                };

                baseScreen.Hits.Add(HitToCreate);


                _context.Hits.Add(HitToCreate);




                var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

                if (!success) return Result<Hit>.Failure("Failed to create hit");
                return Result<Hit>.Success(HitToCreate);

            }


        }
    }
}