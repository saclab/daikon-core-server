using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Persistence;

namespace Application.Votes.DTOs
{
  public class VoteDTO
  {
    public Guid Id { get; set; }
    public Guid ElementId { get; set; }
    public int Positive { get; set; }
    public int Neutral { get; set; }
    public int Negative { get; set; }
    public bool IsVotingAllowed { get; set; }
    public bool HasUserVoted { get; set; }
    public string UsersVote { get; set; }
    public DateTime LastModified { get; set; }

    
  }
}