using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataView
{
  public class TargetDashDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Bucket { get; set; }
    public double ImpactScore { get; set; }
    public double LikeScore { get; set; }
    public string CurrentStage { get; set; }

  }
}