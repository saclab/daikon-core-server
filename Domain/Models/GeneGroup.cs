using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain.Models
{
  public class GeneGroup : Metadata
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<GeneGroupGenes> Genes { get; set; }
  }
}