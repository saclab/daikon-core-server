using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class ProjectParticipatingOrg
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Project BaseProject { get; set; }
    public Guid AppOrgId { get; set; }
    public AppOrg AppOrg { get; set; }
  }
}