using System;
using System.Collections.Generic;

namespace Domain
{
  public class GeneNonPublicData
  {
    public Guid Id { get; set; }

    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }

    /* Section 2: Protein Production List */
    public string ProteinProduction { get; set; }


    /* Section 3: Protein Activity Assay List */
    public string ProteinActivityAssay { get; set; }

    /* Section 4: Hypomorph, Knockdown strain, Phenotype List */
    public string KnockdownStrain { get; set; }
    public string Phenotype { get; set; }


    /* Section 5: CRISPRi Strain List */
    public string CRISPRiStrain { get; set; }


    /* Section 6: Resistance Mutations  */
    public string Mutation { get; set; }
    public string Isolate { get; set; }
    public string ParentStrain { get; set; }
    public string CompoundSmiles { get; set; }
    public string ShiftInMIC { get; set; }
    public string Lab { get; set; }


    

    /* Section 8: Unpublished Structural Information  */
    public string Organization { get; set; }
    public string UnpublishedMethod { get; set; }
    public string Resolution { get; set; }
    public string UnpublishedCondition { get; set; }
    public string Ligand { get; set; }


  }
}