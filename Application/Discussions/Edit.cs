using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Discussions
{
  public class Edit
  {
    public class Command : IRequest<Result<Discussion>>
    {
      public Discussion Discussion { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.Discussion).SetValidator(new DiscussionValidator());
      }

    }


    public class Handler : IRequestHandler<Command, Result<Discussion>>
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


      public async Task<Result<Discussion>> Handle(Command request, CancellationToken cancellationToken)
      {
        var discussionToEdit = await _context.Discussions
          .Include(d => d.Replies)
          .FirstOrDefaultAsync(d => d.Id == request.Discussion.Id);

        if (discussionToEdit == null)
        {
          return Result<Discussion>.Failure("The discussion id could not be found");
        }

        if (discussionToEdit.PostedBy != _userAccessor.GetUsername())
        {
          return Result<Discussion>.Failure("Edits can only be made by the author");
        }

        discussionToEdit.Description = request.Discussion.Description;
        discussionToEdit.Mentions = request.Discussion.Mentions;
        discussionToEdit.Tags = request.Discussion.Tags;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Discussion>.Failure("Failed to edit discussion");
        return Result<Discussion>.Success(discussionToEdit);

      }
    }

  }
}