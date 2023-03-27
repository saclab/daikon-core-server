using System;
using Domain.Core;

namespace Domain
{
  public class Hit : Metadata
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string TargetName { get; set; }
    public string Library { get; set; }
    public string Source { get; set; }
    public string Method { get; set; }
    public double MIC { get; set; }
    public string MICUnit { get; set; }
    public string MICCondition { get; set; }
    public double IC50 { get; set; }
    public string IC50Unit { get; set; }
    public int ClusterGroup { get; set; }
    public string Notes { get; set; }
    public Guid CompoundId { get; set; }
    public Compound Compound { get; set; }


    public Guid VoteId { get; set; }
    public Vote Vote { get; set; }



  }
}