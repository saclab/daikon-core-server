using System;
using System.Collections.Generic;

namespace Domain
{
  public class Gene
  {
    public Guid Id { get; set; }
    public string AccessionNumber { get; set; }
    public string GeneName { get; set; }
    public string Function { get; set; }
    public string Product { get; set; }
    public string FunctionalCategory { get; set; }
    public GenePublicData GenePublicData { get; set; }
    
    /* FOLLOWING ARE NON PUBLIC DATA */
    public GeneNonPublicData GeneNonPublicData { get; set; }
    
    /* Section 1: Essentiality  */
    public List<GeneEssentiality> GeneEssentiality { get; set; }

    /* Section 7: Vulnerability  */
    public GeneVulnerability GeneVulnerability { get; set; }

  }
}