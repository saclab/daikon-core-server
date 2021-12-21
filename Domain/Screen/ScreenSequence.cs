using System;

namespace Domain
{
  public class ScreenSequence
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string AccessionNumber { get; set; }
    public string Method { get; set; }
    public string Protocol { get; set; }
    public string Library { get; set; }
    public string Scientist { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int UnverifiedHitCount { get; set; }
    public int NoOfCompoundsScreened { get; set; }
    public float Concentration { get; set; }

  }
}