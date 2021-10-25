using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Discussions
{
  public class Delete
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Guid Id { get; set; }
    }



    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IUserAccessor userAccessor)
      {
        _context = context;
       
        _userAccessor = userAccessor;
      }


      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var discussionToDelete = await _context.Discussions
          .Include(d => d.Replies)
          .FirstOrDefaultAsync(d => d.Id == request.Id);

        if (discussionToDelete == null)
        {
          return Result<Unit>.Failure("The discussion id could not be found");
        }

        if (discussionToDelete.PostedBy != _userAccessor.GetUsername())
        {
          return Result<Unit>.Failure("Modifications can only be made by the author");
        }

        _context.Remove(discussionToDelete);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Unit>.Failure("Failed to edit discussion");
        return Result<Unit>.Success(Unit.Value);

      }
    }

  }
}