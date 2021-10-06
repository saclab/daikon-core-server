using System;

namespace Domain
{
  public class GeneEssentiality
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Classification { get; set; }
    public string EssentialityCondition { get; set; }
    public string Strain { get; set; }
    public string Method { get; set; }
    public string Reference { get; set; }
    public string Notes { get; set; }
  }
}