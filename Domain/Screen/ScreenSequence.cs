using System;
using System.Text.Json.Serialization;

namespace Domain
{
  public class ScreenSequence
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string TargetName { get; set; }
    public string Method { get; set; }
    public string Protocol { get; set; }
    public string Library { get; set; }
    public string Scientist { get; set; }
    public DateTime StartDate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTime? EndDate { get; set; }
    public int UnverifiedHitCount { get; set; }
    public int NoOfCompoundsScreened { get; set; }
    public float Concentration { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

  }
}