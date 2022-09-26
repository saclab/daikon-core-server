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
    public string Rank { get; set; }
    public double Score1 { get; set; }
    public double Score2 { get; set; }
    public double Score3 { get; set; }

    public string CurrentStage { get; set; }

  }
}