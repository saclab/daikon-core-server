using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class ProjectEditDTO
  {
    public Guid Id { get; set; }
    public string Priority { get; set; }
    public string PriorityDescription { get; set; }
    public string Probability { get; set; }
    public string ProbabilityDescription { get; set; }

    public string TeamPriority { get; set; }
    public string TeamPriorityDescription { get; set; }
    public string TeamProbability { get; set; }
    public string TeamProbabilityDescription { get; set; }
    
    public DateTime FHAStart { get; set; }
    public DateTime FHAPredictedStart { get; set; }
    public string FHADescription { get; set; }

    public DateTime H2LStart { get; set; }
    public DateTime H2LPredictedStart { get; set; }
    public string H2LDescription { get; set; }

    public DateTime LOStart { get; set; }
    public DateTime LOPredictedStart { get; set; }
    public string LODescription { get; set; }

    public DateTime SPStart { get; set; }
    public DateTime SPPredictedStart { get; set; }
    public string SPDescription { get; set; }

    public DateTime PCDDate { get; set; }
    public string PCDDescription { get; set; }

    public DateTime INDStart { get; set; }
    public DateTime INDPredictedStart { get; set; }
    public string INDDescription { get; set; }

    public DateTime ClinicalP1Start { get; set; }
    public DateTime ClinicalP1PredictedStart { get; set; }
    public string ClinicalP1Description { get; set; }
  }
}