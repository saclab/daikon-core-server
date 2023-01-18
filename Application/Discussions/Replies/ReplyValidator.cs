using Domain;
using FluentValidation;

namespace Application.Discussions.Replies
{
  public class ReplyValidator : AbstractValidator<Reply>
  {
    public ReplyValidator()
    {
      RuleFor(reply => reply.DiscussionId).NotEmpty();
      RuleFor(reply => reply.Body).NotEmpty();
    }
  }
}