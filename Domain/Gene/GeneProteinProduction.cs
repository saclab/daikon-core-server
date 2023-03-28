using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class GeneProteinProduction : Metadata
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Production { get; set; }
    public string Method { get; set; }
    public DateTime DateProduced { get; set; }
    public string URL { get; set; }
    public string PMID { get; set; }
    public string Purity { get; set; }
    public string Notes { get; set; }

  }
}