// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using Application.Core;
// using Application.Interfaces;
// using AutoMapper;
// using Domain;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;

// namespace Application.Projects
// {
//     public class Create
//   {
//     public class Command : IRequest<Result<Project>>
//     {
//       public Project NewProject { get; set; }
//     }

//     // public class CommandValidator : AbstractValidator<Command>
//     // {
//     //   public CommandValidator()
//     //   {
//     //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
//     //   }

//     // }

//     public class Handler : IRequestHandler<Command, Result<Project>>
//     {
//       private readonly DataContext _context;
//       private readonly IMapper _mapper;
//       private readonly IUserAccessor _userAccessor;

//       public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
//       {
//         _context = context;
//         _mapper = mapper;
//         _userAccessor = userAccessor;
//       }
//       public async Task<Result<Project>> Handle(Command request, CancellationToken cancellationToken)
//       {
       
//         var baseScreen = await _context.Screens.FirstOrDefaultAsync
//             (s => s.Id == request.NewProject.ScreenId);

//         /*chek if gene id is correct*/
//         if (baseScreen == null)
//         {
//           return Result<Project>.Failure("Invalid Screen ID");
//         }

//         var newProject = new Project();
//         _mapper.Map(request.NewProject, newProject);

//         newProject.Id =  Guid NewProjectGid = Guid.NewGuid();



//         var org = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Id == request.NewScreen.Org.Id);
//         if (org == null)
//         {
//           return Result<Screen>.Failure("Bad org id");
//         }


//         /*Screen Name Sequence Number */
//         string screenName = null;

//         var testScreen = await _context.Screens.Where((s) => s.TargetId
//                                                           == request.NewScreen.TargetId)
//                                                           .OrderByDescending(s => s.ScreenName).ToListAsync();


//         if (!testScreen.Any())
//         {
//           screenName = baseTarget.GeneName + "-" + "1";
//         }
//         else
//         {
//           var lastScreenName = testScreen.First().ScreenName;
//           var lastScreenNumber = lastScreenName != null ? Int32.Parse(lastScreenName.Split('-').Last()) : 0;
//           lastScreenNumber = lastScreenNumber + 1;
//           screenName = baseTarget.GeneName + "-" + lastScreenNumber.ToString();
//         }



//         var ScreenToCreate = new Screen
//         {
//           Id = ScreenGid,
//           BaseTarget = baseTarget,
//           TargetId = baseTarget.Id,
//           AccessionNumber = baseTarget.AccessionNumber,
//           GeneName = baseTarget.GeneName,
//           ScreenName = screenName,
//           Status = "New",
//           Promoter = _userAccessor.GetUsername(),
//           PromotionDate = request.NewScreen.PromotionDate,
//           Org = org,
//           OrgId = org.Id,
//           Notes = request.NewScreen.Notes
//         };

//         _context.Screens.Add(ScreenToCreate);

//         var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

//         if (!success) return Result<Screen>.Failure("Failed to create screen");
//         return Result<Project>.Success(ScreenToCreate);

//       }


//     }
// }