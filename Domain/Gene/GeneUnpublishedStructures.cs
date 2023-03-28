using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class GeneUnpublishedStructures : Metadata
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Organization { get; set; }
    public string Method { get; set; }
    public string Resolution { get; set; }
    public string ResolutionUnit { get; set; }
    public string Ligands { get; set; }
    public string Researcher { get; set; }
    public string URL { get; set; }
    public string Reference { get; set; }
    public string Notes { get; set; }
  }
}