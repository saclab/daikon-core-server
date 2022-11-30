using System;
using System.Collections.Generic;
using Domain;

namespace Application.Screens.DTOs
{
  public class ScreenDTO
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public Target BaseTarget { get; set; }
    public Guid TargetId { get; set; }
    public String ScreenName { get; set; }
    public string Method { get; set; }
    public string TargetName { get; set; }
    public string GeneName { get; set; }
    public string Status { get; set; }
    public AppOrg Org { get; set; }
    public Guid OrgId { get; set; }
    public DateTime PromotionDate { get; set; }
    public string Promoter { get; set; }
    public List<ScreenSequenceDTO> ScreenSequences { get; set; }
    public List<HitDTO> ValidatedHits { get; set; }
    public string Notes { get; set; }
  }
}