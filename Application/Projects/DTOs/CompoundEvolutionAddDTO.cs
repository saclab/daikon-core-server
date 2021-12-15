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
    public string MIC { get; set; }
    public string IC50 { get; set; }
  }
}