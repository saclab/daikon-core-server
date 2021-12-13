using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class ProjectCompoundEvolution
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid CompoundId { get; set; }
    public Compound Compound { get; set; }
    public DateTime AddedOnDate { get; set; }
    public string AddedOnStage { get; set; }
    public string Notes { get; set; }
    public string MIC { get; set; }
    public string IC50 { get; set; }

  }
}