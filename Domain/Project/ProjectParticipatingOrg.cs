using System;
using Domain.Core;

namespace Domain
{
  public class ProjectParticipatingOrg : Metadata
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    //public Project BaseProject { get; set; }
    public Guid AppOrgId { get; set; }
    public AppOrg AppOrg { get; set; }
  }
}