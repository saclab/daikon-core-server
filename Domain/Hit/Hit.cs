using System;

namespace Domain
{
  public class Hit
  {
    public Guid Id { get; set; }
    public Target BaseScreen { get; set; }
    public Guid ScreenId { get; set; }
    public string Library { get; set; }
    public string CompoundId { get; set; }
    public string EnzymeActivity { get; set; }
    public string Method { get; set; }
    public string MIC { get; set; }
    public string Structure { get; set; }
    public string ClusterGroup { get; set; }

  }
}