using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace DataView.Compounds
{
  public class DetailViewDTO
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string ExternalCompoundIds { get; set; }
    public String Smiles { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Project> ProjectsWithPrimaryStructure { get; set; }
    public List<Project> ProjectsWithBaseHits { get; set; }
    public List<Project> ProjectsWithCompoundEvolution { get; set; }
    public List<Hit> Hits { get; set; }
    public List<Screen> Screen { get; set; }
  }
}