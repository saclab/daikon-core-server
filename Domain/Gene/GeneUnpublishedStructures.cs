using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneUnpublishedStructures
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Organization { get; set; }
    public string Method { get; set; }
    public string Resolution { get; set; }
    public string Ligands { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}