using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain
{
  public class Project : Metadata
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectType { get; set; }
    public string ProjectLegacyId { get; set; }
    public Guid? ScreenId { get; set; }
    public Screen BaseScreen { get; set; }
    public string ScreenName { get; set; }
    public string TargetName { get; set; }
    public Guid? TargetId { get; set; }

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

    public string TeamPriority { get; set; }
    public string TeamPriorityDescription { get; set; }

    public string TeamProbability { get; set; }
    public string TeamProbabilityDescription { get; set; }

    public string Resource { get; set; }
    public string ResourceDescription { get; set; }

    public bool HAEnabled { get; set; }
    public DateTime HAStart { get; set; }
    public DateTime HAPredictedStart { get; set; }
    public string HADescription { get; set; }

    public bool H2LEnabled { get; set; }
    public DateTime H2LStart { get; set; }
    public DateTime H2LPredictedStart { get; set; }
    public string H2LDescription { get; set; }

    public bool LOEnabled { get; set; }
    public DateTime LOStart { get; set; }
    public DateTime LOPredictedStart { get; set; }
    public string LODescription { get; set; }

    public bool SPEnabled { get; set; }
    public DateTime SPStart { get; set; }
    public DateTime SPPredictedStart { get; set; }
    public string SPDescription { get; set; }

    public bool PCDEnabled { get; set; }
    public DateTime PCDDate { get; set; }
    public string PCDDescription { get; set; }

    public bool INDEnabled { get; set; }
    public DateTime INDStart { get; set; }
    public DateTime INDPredictedStart { get; set; }
    public string INDDescription { get; set; }

    public bool ClinicalP1Enabled { get; set; }
    public DateTime ClinicalP1Start { get; set; }
    public DateTime ClinicalP1PredictedStart { get; set; }
    public string ClinicalP1Description { get; set; }

    public DateTime LastModified { get; set; }
    public DateTime? TerminationDate { get; set; }
    public DateTime? EOLDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public bool isCompleted { get; set; }

  }
}