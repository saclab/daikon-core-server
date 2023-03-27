using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain
{
  public class Screen : Metadata
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public Target BaseTarget { get; set; }
    public Guid? TargetId { get; set; }
    public String ScreenName { get; set; }
    public String ScreenType { get; set; }
    public string Method { get; set; }
    public string TargetName { get; set; }
    public string GeneName { get; set; }
    public string Status { get; set; }
    public AppOrg Org { get; set; }
    public Guid OrgId { get; set; }
    public DateTime PromotionDate { get; set; }
    public string Promoter { get; set; }
    public List<ScreenSequence> ScreenSequences { get; set; }
    public List<Hit> ValidatedHits { get; set; }
    public string Notes { get; set; }

  }
}