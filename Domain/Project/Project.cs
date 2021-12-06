using System;
using System.Collections.Generic;

namespace Domain
{
  public class Project
  {
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public Guid ScreenId { get; set; }
    public Screen BaseScreen { get; set; }
    public List<ProjectBaseHits> BaseHits { get; set; }
    public Guid RepresentationStructureId { get; set; }
    public Compound RepresentationStructure { get; set; }
    public string Status { get; set; }
    public string CurrentStage { get; set; }
    public string CurrentStageDescription { get; set; }
    public Guid PrimaryOrgId { get; set; }
    public AppOrg PrimaryOrg { get; set; }
    public List<ProjectSupportingOrg> SupportingOrgs { get; set; }
    public string ProjectDisclosure { get; set; }
    public List<ProjectParticipatingOrg> ParticipatingOrgs { get; set; }
    public DateTime DisclosureDate { get; set; }
    public string Priority { get; set; }
    public string PriorityDescription { get; set; }
    public string Probability { get; set; }
    public string ProbabilityDescription { get; set; }
    public string Resource { get; set; }
    public string ResourceDescription { get; set; }
    public DateTime FHAStart { get; set; }
    public string FHADescription { get; set; }
    public DateTime H2LStart { get; set; }
    public string H2LDescription { get; set; }
    public DateTime LOStart { get; set; }
    public string LODescription { get; set; }
    public DateTime SPStart { get; set; }
    public string SPCDescription { get; set; }
    public DateTime PCDDate { get; set; }
    public string PCDDescription { get; set; }
    public DateTime INDStart { get; set; }
    public string INDDescription { get; set; }
    public DateTime P1Start { get; set; }
    public string P1Description { get; set; }

  }
}