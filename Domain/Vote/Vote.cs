using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class Vote
  {
    public Guid Id { get; set; }
    public Guid ElementId { get; set; }
    public int Positive { get; set; }
    public int Neutral { get; set; }
    public int Negative { get; set; }
    public bool IsVotingAllowed { get; set; }
    public DateTime LastModified { get; set; }
  }
}