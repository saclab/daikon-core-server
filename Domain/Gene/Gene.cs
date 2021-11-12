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
    // public GeneNonPublicData GeneNonPublicData { get; set; }
    public List<GeneEssentiality> GeneEssentiality { get; set; }
    public List<GeneProteinProduction> GeneProteinProduction { get; set; }
    public List<GeneProteinActivityAssay> GeneProteinActivityAssay { get; set; }
    public List<GeneCRISPRiStrain> GeneCRISPRiStrain { get; set; }
    public List<GeneResistanceMutation> GeneResistanceMutation { get; set; }
    public GeneVulnerability GeneVulnerability { get; set; }
    public List<GeneUnpublishedStructures> GeneUnpublishedStructures { get; set; }



  }
}