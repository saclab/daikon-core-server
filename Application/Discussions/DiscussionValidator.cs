using Domain;
using FluentValidation;

namespace Application.Discussions
{
  public class DiscussionValidator : AbstractValidator<Discussion>
  {
    public DiscussionValidator()
    {
      RuleFor(discussion => discussion.Reference).NotEmpty();
      RuleFor(discussion => discussion.Section).NotEmpty();
      RuleFor(discussion => discussion.Description).NotEmpty();
      RuleFor(discussion => discussion.Topic).NotEmpty();
    }
  }
}