
using CsvHelper.Configuration.Attributes;

namespace Adapter.GenePool.Mycobrowser.DTO
{
  public class MycobrowserGeneCSVModel
  {
    [Name("Locus")]
    public string AccessionNumber { get; set; }

    [Name("Name")]
    public string GeneName { get; set; }

    [Name("Function")]
    public string Function { get; set; }

    [Name("Product")]
    public string Product { get; set; }

    [Name("Functional_Category")]
    public string FunctionalCategory { get; set; }

    /* Section 1: General annotation */
    [Name("Feature")]
    public string Type { get; set; }

    //public string Proteomics { get; set; }
    //public string Mutant { get; set; }
    [Name("Comments")]
    public string Comments { get; set; }


    /* Section 2: Coordinates */
    [Name("Start")]
    public string Start { get; set; }
    [Name("Stop")]
    public string End { get; set; }
    [Name("Strand")]
    public string Orientation { get; set; }


    /* Section 3: Gene summary information */
    // public string GeneLength { get; set; }
    // public string Location { get; set; }


    /* Section 4: Protein summary information */
    // public string MolecularMass { get; set; }
    // public string IsoelectricPoint { get; set; }
    // public string ProteinLength { get; set; }


    /* Section 5: Structural information */
    [Name("UniProt_AC")]
    public string PFAM { get; set; }


    /* Section 6: Orthologues */
    [Name("Orthologues M. leprae")]
    public string M_Leprae { get; set; }

    [Name("Orthologues M. marinum")]
    public string M_Marinum { get; set; }

    [Name("Orthologues M. smegmatis")]
    public string M_Smegmatis { get; set; }

    [Name("Orthologues M. bovis")]
    public string M_Bovis { get; set; }


    [Name("UniProt")]
    public string UniProt { get; set; }
  }
}