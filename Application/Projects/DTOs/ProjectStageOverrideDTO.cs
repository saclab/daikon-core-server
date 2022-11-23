using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class ProjectStageOverrideDTO
  {
    public Guid ProjectId { get; set; }
    public string StageString { get; set; }
  }
}