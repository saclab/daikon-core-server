using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class ProjectSupportingOrg : Metadata
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    //public Project BaseProject { get; set; }
    public Guid AppOrgId { get; set; }
    public AppOrg AppOrg { get; set; }

  }
}