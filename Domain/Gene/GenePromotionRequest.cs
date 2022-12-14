using System;
using System.Collections.Generic;

namespace Domain
{
  public class GenePromotionRequest
  {
    public Guid Id { get; set; }
    public List<GenePromtionRequestGene> GenePromtionRequestGenes { get; set; }
    public string TargetName { get; set; }
    public string TargetType { get; set; }
    public string GenePromotionRequestStatus { get; set; }
    public List<GenePromotionRequestValue> GenePromotionRequestValues { get; set; }

  }
}