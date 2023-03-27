using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class ProjectCompoundEvolution : Metadata
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid CompoundId { get; set; }
    public Compound Compound { get; set; }
    public DateTime AddedOnDate { get; set; }
    public string AddedOnStage { get; set; }
    public string Notes { get; set; }
    public double MIC { get; set; }
    public string MICUnit { get; set; }
    public double IC50 { get; set; }
    public string IC50Unit { get; set; }


  }
}