using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class CompoundEvolutionAddDTO
  {
    public String Smile { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }
    public Guid ProjectId { get; set; }
    public string Notes { get; set; }
    public double MIC { get; set; }
    public double IC50 { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}