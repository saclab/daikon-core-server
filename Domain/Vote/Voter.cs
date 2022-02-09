using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class Voter
  {
    public Guid Id { get; set; }
    public Guid VoteId { get; set; }
    public string VoterEmail { get; set; }
    public bool VotedPositive { get; set; }
    public bool VotedNeutral { get; set; }
    public bool VotedNegative { get; set; }
    public DateTime VotedOn { get; set; }
    public string Comment { get; set; }
  }
}