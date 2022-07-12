using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class GeneExternalId
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public String ExternalIdRef { get; set; }
    public String ExternalId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}