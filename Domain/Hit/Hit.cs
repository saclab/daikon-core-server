using System;

namespace Domain
{
  public class Hit
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string TargetName { get; set; }
    public string Library { get; set; }
    public string Source { get; set; }
    public string Method { get; set; }
    public double MIC { get; set; }
    public string MICCondition { get; set; }
    public double IC50 { get; set; }
    public int ClusterGroup { get; set; }
    public Guid CompoundId { get; set; }
    public Compound Compound { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public Guid VoteId { get; set; }
    public Vote Vote { get; set; }



  }
}