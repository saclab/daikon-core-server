using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneProteinActivityAssay
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string ProteinActivityAssay { get; set; }
    public string AssayType { get; set; }
    public string AssayThroughput { get; set; }
  }
}