using System;
using System.Collections.Generic;

namespace Domain
{
  public class TargetScorecard
  {
    public Guid Id { get; set; }
    public Guid TargetID { get; set; }
    public string TargetName { get; set; }
    public List<TargetScoreCardValue> TargetScoreCardValues { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

  }
}