using Domain;

namespace Application.Targets.DTOs
{
  public class TargetImportDTO : GenePromotionRequest
  {
    public string Bucket { get; set; }
    public double ImpactScore { get; set; }
    public double LikeScore { get; set; }
    public double HTSFeasibility { get; set; }
    public double SBDFeasibility { get; set; }
    public double Progressibility { get; set; }
    public double Safety { get; set; }

  }
}