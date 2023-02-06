using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class SupportingOrgDTO
  {
    public Guid ProjectId { get; set; }
    public List<Guid> ModifiedSupportingOrgs { get; set; }
  }
}