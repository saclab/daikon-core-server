using System;

namespace Domain
{
    public class GeneNonPublicData
    {
        public Guid Id { get; set; }
        public Gene Gene { get; set; }
        public Guid GeneID { get; set; }

        /* Section 1: Essentiality  */
        public string Classification { get; set; }
        public string EssentialityCondition { get; set; }
        public string Strain { get; set; }
        public string Method { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }

        
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


        /* Section 7: Vulnerability  */
        public string Rank { get; set; }
        public string U_Vi { get; set; }
        public string I_Vi { get; set; }
        public string Vi_Ratio { get; set; }
        public string VulnerabilityCondition { get; set; }
        public string Operon { get; set; }
        public string Confounded { get; set; }
        public string Shell_2015Operon { get; set; }


        /* Section 8: Unpublished Structural Information  */
        public string Organization { get; set; }
        public string UnpublishedMethod { get; set; }
        public string Resolution { get; set; }
        public string UnpublishedCondition { get; set; }
        public string Ligand { get; set; }


    }
}