using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class TargetGene
  {
    public Guid Id { get; set; }
    public Guid TargetId { get; set; }
    public Guid GeneId { get; set; }
    public string AccessionNumber { get; set; }
    public Gene Gene { get; set; }
    public Guid StrainId { get; set; }
  }
}