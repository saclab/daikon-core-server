using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Screens.DTOs
{
  public class ScreenSequenceDTO
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
    public string Concentration { get; set; }
  }
}