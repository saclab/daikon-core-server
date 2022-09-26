using Domain;

namespace Application.Targets.DTOs
{
  public class TargetImportDTO : GenePromotionRequest
  {

    public string Rank { get; set; }
    public string SimpleProteinAccessionNumber { get; set; }
    public double Score1 { get; set; }
    public double Score2 { get; set; }
    public double Score3 { get; set; }
    
  }
}