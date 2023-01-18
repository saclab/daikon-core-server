using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Projects.DTOs
{
  public class ProjectTerminateDTO
  {
    public Guid Id { get; set; }
    public string ProjectName { get; set; }

  }
}