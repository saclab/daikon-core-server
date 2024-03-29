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

namespace Application.Screens.Phenotypic
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

        string screenName = request.NewScreen.ScreenName;
        // int idx = screenName.LastIndexOf('-');
        // string baseScreenName = screenName.Substring(0, idx);

        var checkScreenName = await _context.Screens.Where((s) => (s.ScreenName.Contains(screenName)
                                                          ) && (s.ScreenType == ScreenType.Phenotypic.Value))
                                                          .OrderByDescending(s => s.ScreenName).ToListAsync();

        /*chek if gene id is correct*/
        if (!checkScreenName.Any())
        {
          screenName = screenName + "-" + "1";
        }
        else
        {
          int maxScreen = 1;
          foreach (var t in checkScreenName)
          {
            int screenNum = Int32.Parse(t.ScreenName.Split('-').Last());
            maxScreen = maxScreen > screenNum ? maxScreen : screenNum;
          }
          maxScreen = maxScreen + 1;
          screenName = screenName + "-" + maxScreen.ToString();
        }

        var org = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Id == request.NewScreen.Org.Id);
        if (org == null)
        {
          return Result<Screen>.Failure("Bad org id");
        }


        var ScreenToCreate = new Screen
        {
          Id = ScreenGid,
          StrainId = request.NewScreen.StrainId,
          ScreenType = ScreenType.Phenotypic.Value,
          ScreenName = screenName,
          Method = request.NewScreen.Method,
          Status = "New",
          Promoter = _userAccessor.GetUsername(),
          PromotionDate = request.NewScreen.PromotionDate,
          Org = org,
          OrgId = org.Id,
          Notes = request.NewScreen.Notes
        };

        ScreenToCreate.CreatedAt = DateTime.UtcNow;
        ScreenToCreate.CreatedBy = _userAccessor.GetUsername();

        _context.Screens.Add(ScreenToCreate);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Screen>.Failure("Failed to create screen");
        return Result<Screen>.Success(ScreenToCreate);

      }


    }
  }
}