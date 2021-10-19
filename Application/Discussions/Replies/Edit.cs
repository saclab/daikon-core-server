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
  public class Edit
  {
    public class Command : IRequest<Result<Reply>>
    {
      public Discussion Reply { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Reply).SetValidator(new ReplyValidator());
    //   }

    // }

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
        var replyToEdit = await _context.Replies
          .FirstOrDefaultAsync(r => r.Id == request.Reply.Id);

        if (replyToEdit == null)
        {
          return Result<Reply>.Failure("The Reply id could not be found");
        }

        if (replyToEdit.PostedBy != _userAccessor.GetUsername())
        {
          return Result<Reply>.Failure("Edits can only be made by the author");
        }

        replyToEdit.Body = request.Reply.Topic;
        replyToEdit.Mentions = request.Reply.Mentions;
        replyToEdit.Tags = request.Reply.Tags;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Reply>.Failure("Failed to edit Reply");
        return Result<Reply>.Success(replyToEdit);

      }
    }

  }
}