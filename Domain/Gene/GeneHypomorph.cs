using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneHypomorph
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string KnockdownStrain { get; set; }
    public string Phenotype { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}