using System;
using System.Collections.Generic;

namespace Domain
{
  public class Project
  {
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public Guid ScreenId { get; set; }
    public List<Hit> Compounds { get; set; }
    public Compound RepresentationStructure { get; set; }
    public string Status { get; set; }
    public string CurrentStage { get; set; }
    public string CurrentStageDescription { get; set; }
    public AppOrg PrimaryOrg { get; set; }
    public List<AppOrg> SupportingOrg { get; set; }
    public string ProjectDisclosure { get; set; }
    public List<AppOrg> ParticipatingOrganizations { get; set; }
    public DateTime DisclosureDate { get; set; }
    public string Priority { get; set; }
    public string PriorityDescription { get; set; }
    public string Probability { get; set; }
    public string ProbabilityDescription { get; set; }
    public string Resource { get; set; }
    public string ResourceDescription { get; set; }
    public DateTime FHAStart { get; set; }
    public DateTime H2LStart { get; set; }
    public DateTime LOStart { get; set; }
    public DateTime SPStart { get; set; }
    public DateTime PCDDate { get; set; }
    public DateTime INDStart { get; set; }
    public DateTime P1Start { get; set; }

  }
}