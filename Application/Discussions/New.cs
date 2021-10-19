using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Discussions
{
  public class New
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

        var newDiscussion = new Discussion
        {
          Id = Guid.NewGuid(),
          Reference = request.Discussion.Reference,
          Section = request.Discussion.Section,
          Topic = request.Discussion.Topic,
          PostedBy = _userAccessor.GetUsername(),
          Timestamp = DateTime.Now,
          Mentions = request.Discussion.Mentions,
          Tags = request.Discussion.Tags,
          Replies = new List<Reply>()
        };

        _context.Discussions.Add(newDiscussion);
        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Discussion>.Failure("Failed to create new discussion");
        return Result<Discussion>.Success(newDiscussion);

      }
    }
  }
}