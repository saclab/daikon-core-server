using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
  public class GeneGroupGenes
  {
    public Guid Id { get; set; }
    public Guid GeneGroupId { get; set; }
    public Guid GeneId { get; set; }
    public string AccessionNumber { get; set; }
    public Gene Gene { get; set; }
    public Guid StrainId { get; set; }
  }
}