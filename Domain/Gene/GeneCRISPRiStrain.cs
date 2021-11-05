using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneCRISPRiStrain
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string CRISPRiStrain { get; set; }

  }
}