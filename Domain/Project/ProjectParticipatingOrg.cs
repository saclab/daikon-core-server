using System;

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