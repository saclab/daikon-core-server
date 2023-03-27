using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain
{
  public class TargetScorecard : Metadata
  {
    public Guid Id { get; set; }
    public Guid TargetID { get; set; }
    public string TargetName { get; set; }
    public List<TargetScoreCardValue> TargetScoreCardValues { get; set; }

  }
}