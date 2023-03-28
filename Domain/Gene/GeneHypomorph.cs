using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class GeneHypomorph : Metadata
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string KnockdownStrain { get; set; }
    public string Phenotype { get; set; }
    public string Notes { get; set; }

  }
}