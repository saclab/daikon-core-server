using System;
using System.Collections.Generic;

namespace Domain
{
  public class TargetScorecard
  {
    public Guid Id { get; set; }
    public Guid TargetID { get; set; }
    public string TargetAccessionNumber { get; set; }
    public List<TargetScoreCardValue> TargetScoreCardValues { get; set; }

  }
}