using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneProteinProduction
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string ProteinProduction { get; set; }
    public string Quantity { get; set; }
    public string Purity { get; set; }
    public DateTime Date { get; set; }
  }
}