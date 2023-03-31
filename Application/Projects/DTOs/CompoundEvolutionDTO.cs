using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class CompoundEvolutionDTO
  {
    public Guid Id { get; set; }
    public String Smile { get; set; }
    public Guid CompoundId { get; set; }
    public string ExternalCompoundIds { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }
    public Guid ProjectId { get; set; }
    public string Notes { get; set; }
    public string MIC { get; set; }
    public string IC50 { get; set; }
    public string AddedOnStage { get; set; }
    public DateTime AddedOnDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}