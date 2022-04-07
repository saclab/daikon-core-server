using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class ProjectPriorityProbabilityDTO
  {
    public Guid Id { get; set; }
    public string TeamPriority { get; set; }
    public string TeamPriorityDescription { get; set; }
    public string TeamProbability { get; set; }
    public string TeamProbabilityDescription { get; set; }
  }
}