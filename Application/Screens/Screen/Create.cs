using System;
using System.Collections.Generic;
using System.Linq;
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

        var org = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Id == request.NewScreen.Org.Id);
        if (org == null)
        {
          return Result<Screen>.Failure("Bad org id");
        }


        /*Screen Name Sequence Number */
        string screenName = null;

        var testScreen = await _context.Screens.Where((s) => s.TargetId
                                                          == request.NewScreen.TargetId)
                                                          .OrderByDescending(s => s.ScreenName).ToListAsync();


        if (!testScreen.Any())
        {
          screenName = baseTarget.Name + "-" + "1";
        }
        else
        {
          var lastScreenName = testScreen.First().ScreenName;
          var lastScreenNumber = lastScreenName != null ? Int32.Parse(lastScreenName.Split('-').Last()) : 0;
          lastScreenNumber = lastScreenNumber + 1;
          screenName = baseTarget.Name + "-" + lastScreenNumber.ToString();
        }



        var ScreenToCreate = new Screen
        {
          Id = ScreenGid,
          BaseTarget = baseTarget,
          TargetId = baseTarget.Id,
          TargetName = baseTarget.Name,
          ScreenName = screenName,
          Method = request.NewScreen.Method,
          Status = "New",
          Promoter = _userAccessor.GetUsername(),
          PromotionDate = request.NewScreen.PromotionDate,
          Org = org,
          OrgId = org.Id,
          Notes = request.NewScreen.Notes
        };

        _context.Screens.Add(ScreenToCreate);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Screen>.Failure("Failed to create screen");
        return Result<Screen>.Success(ScreenToCreate);

      }


    }
  }
}