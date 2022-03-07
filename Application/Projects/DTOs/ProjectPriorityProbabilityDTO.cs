using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class ProjectPriorityProbabilityDTO
  {
    public Guid Id { get; set; }
    public string Priority { get; set; }
    public string PriorityDescription { get; set; }
    public string Probability { get; set; }
    public string ProbabilityDescription { get; set; }
  }
}