using System;
using System.Collections.Generic;

namespace Domain
{
  public class GenePromotionRequest
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public Gene Gene { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string GenePromotionRequestStatus { get; set; }
    public List<GenePromotionRequestValue> GenePromotionRequestValues { get; set; }

  }
}