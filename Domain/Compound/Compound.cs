using System;
using System.Collections.Generic;

namespace Domain
{
  public class Compound
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string ExternalCompundIds { get; set; }
    public String Smile { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }
    public DateTime CreatedAt { get; set; }
    
  }
}