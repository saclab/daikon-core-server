using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Projects.DTOs
{
  public class UnlinkedProjectCreateDTO
  {
    public string ProjectName { get; set; }
    public Compound RepresentationStructure { get; set; }
    public string RepresentationStructureSMILE { get; set; }
    public string RepresentationStructureExternalCompoundIds { get; set; }
    public AppOrg PrimaryOrg { get; set; }
    public List<AppOrg> SupportingOrgs { get; set; }
    public DateTime FHAStart { get; set; }
    public string FHADescription { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }
    public double MIC { get; set; }
    public double IC50 { get; set; }
  }
}