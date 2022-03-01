using Application.Votes.DTOs;
using Domain;
using FluentValidation;

namespace Application.Votes
{
  public class VoteValidator : AbstractValidator<RegisterVoteDTO>
  {
    public VoteValidator()
    {
      RuleFor(vote => vote.VoteId).NotEmpty();
      RuleFor(vote => vote.VoteButton).NotEmpty();
      RuleFor(vote => vote.VoteButton).Matches("^(Positive|Neutral|Negative)$");
    }

  }
}