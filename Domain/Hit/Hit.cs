using System;

namespace Domain
{
  public class Hit
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string AccessionNumber { get; set; }
    public string Library { get; set; }
    public string Source { get; set; }
    public string Method { get; set; }
    public string MIC { get; set; }
    public string IC50 { get; set; }
    public int ClusterGroup { get; set; }
    public Guid CompoundId { get; set; }
    public Compound Compound { get; set; }

  }
}