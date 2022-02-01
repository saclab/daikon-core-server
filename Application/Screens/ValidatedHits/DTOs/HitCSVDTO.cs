using System;

namespace Application.Screens.ValidatedHits.DTOs
{
  public class HitCSVDTO
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string SaccId { get; set; }
    public string TargetName { get; set; }
    public string Library { get; set; }
    public string Source { get; set; }
    public string Method { get; set; }
    public string MIC { get; set; }
    public string IC50 { get; set; }
    public string ClusterGroup { get; set; }
    public string Smile { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }

    
  }
}