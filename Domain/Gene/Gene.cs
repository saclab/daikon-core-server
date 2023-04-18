using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain
{
  public class Gene : Metadata
  {
    /*
      Define: A gene is a basic unit of heredity and a sequence of nucleotides 
      in DNA that encodes the synthesis of a gene product, either RNA or protein.
    */


    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public Strain Strain { get; set; }
    public string AccessionNumber { get; set; }
    public string GeneName { get; set; }
    public string Function { get; set; }
    public string Product { get; set; }
    public string FunctionalCategory { get; set; }
    public List<GeneExternalId> GeneExternalIds { get; set; }
    public GenePublicData GenePublicData { get; set; }

    /* FOLLOWING ARE NON PUBLIC DATA */
    // public GeneNonPublicData GeneNonPublicData { get; set; }
    public List<GeneEssentiality> GeneEssentiality { get; set; }
    public List<GeneProteinProduction> GeneProteinProduction { get; set; }
    public List<GeneProteinActivityAssay> GeneProteinActivityAssay { get; set; }
    public List<GeneCRISPRiStrain> GeneCRISPRiStrain { get; set; }
    public List<GeneResistanceMutation> GeneResistanceMutation { get; set; }
    public List<GeneVulnerability> GeneVulnerability { get; set; }
    public List<GeneHypomorph> GeneHypomorphs { get; set; }
    public List<GeneUnpublishedStructures> GeneUnpublishedStructures { get; set; }



  }
}