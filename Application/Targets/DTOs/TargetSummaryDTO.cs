using System;
using Domain;

namespace Application.Targets.DTOs
{
  public class TargetSummaryDTO
  {
    public Guid Id { get; set; }

    public string Background { get; set; }

    public string Enablement { get; set; }

    public string Strategy { get; set; }

    public string Challenges { get; set; }
  }
}
