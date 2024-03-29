using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Projects.DTOs
{
  public class ProjectCreateDTO
  {
    public string ProjectName { get; set; }
    public string ProjectLegacyId { get; set; }
    public Guid ScreenId { get; set; }
    public List<Hit> BaseHits { get; set; }
    public Compound RepresentationStructure { get; set; }
    public AppOrg PrimaryOrg { get; set; }
    public List<AppOrg> SupportingOrgs { get; set; }
    public DateTime HAStart { get; set; }
    public string HADescription { get; set; }
  }
}