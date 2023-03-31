using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class GeneProteinActivityAssay : Metadata
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Assay { get; set; }
    public string Method { get; set; }
    public string Throughput { get; set; }
    public string URL { get; set; }
    public string PMID { get; set; }
    public string Reference { get; set; }
  }
}