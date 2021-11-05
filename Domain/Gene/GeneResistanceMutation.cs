using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneResistanceMutation
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Mutation { get; set; }
    public string Isolate { get; set; }
    public string ParentStrain { get; set; }
    public string Compound { get; set; }
    public string ShiftInMIC { get; set; }
    public string Org { get; set; }
  }
}