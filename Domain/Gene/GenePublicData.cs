using System;
using Domain.Core;

namespace Domain
{
  public class GenePublicData : Metadata
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }

    /* Section 1: General annotation */
    public string Type { get; set; }
    public string Proteomics { get; set; }
    public string Mutant { get; set; }
    public string Comments { get; set; }


    /* Section 2: Coordinates */
    public string Start { get; set; }
    public string End { get; set; }
    public string Orientation { get; set; }


    /* Section 3: Gene summary information */
    public string GeneLength { get; set; }
    public string GeneLengthUnit { get; set; }
    public string Location { get; set; }
    public string GeneSequence { get; set; }


    /* Section 4: Protein summary information */
    public string MolecularMass { get; set; }
    public string MolecularMassUnit { get; set; }
    public string IsoelectricPoint { get; set; }
    public string IsoelectricPointUnit { get; set; }
    public string ProteinLength { get; set; }
    public string ProteinLengthUnit { get; set; }
    public string ProteinSequence { get; set; }


    /* Section 5: Structural information */
    public string PFAM { get; set; }


    /* Section 6: Orthologues */
    public string M_Leprae { get; set; }
    public string M_Marinum { get; set; }
    public string M_Smegmatis { get; set; }


    /* Section 7: Protein Databank */
    public string Cryo { get; set; }
    public string XRay { get; set; }
    public string Model { get; set; }
    public string Ligand { get; set; }

  }
}