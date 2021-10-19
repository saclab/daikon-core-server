using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Discussions.Replies
{
  public class Command : IRequest<Result<Reply>>
  {
    public Reply Reply { get; set; }
  }

  public class CommandValidator : AbstractValidator<Command>
  {
    public CommandValidator()
    {
      RuleFor(cmd => cmd.Reply).SetValidator(new ReplyValidator());
    }

  }


  public class Handler : IRequestHandler<Command, Result<Reply>>
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


    public async Task<Result<Reply>> Handle(Command request, CancellationToken cancellationToken)
    {
      var toDiscussion = await _context.Discussions
        .Include(d => d.Replies)
        .FirstOrDefaultAsync(d => d.Id == request.Reply.DiscussionId);

      if (toDiscussion == null)
      {
        return Result<Reply>.Failure("The discussion id could not be found");
      }

      var newReply = new Reply
      {
        Id = new System.Guid(),
        DiscussionId = toDiscussion.Id,
        Body = request.Reply.Body,
        PostedBy = _userAccessor.GetUsername(),
        Timestamp = DateTime.Now,
        Mentions = request.Reply.Mentions,
        Tags = request.Reply.Tags,
      };

      _context.Replies.Add(newReply);

      toDiscussion.Replies.Add(newReply);

      var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

      if (!success) return Result<Reply>.Failure("Failed to add a reply");
      return Result<Reply>.Success(newReply);

    }
  }
}
