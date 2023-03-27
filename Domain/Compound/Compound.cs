using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain
{
  public class Compound : Metadata
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string ExternalCompoundIds { get; set; }
    public String Smile { get; set; }
    public string MolWeight { get; set; }
    public string MolWeightUnit { get; set; }
    public string MolArea { get; set; }
    public string MolAreaUnit { get; set; }
    public string MolVolume { get; set; }
    public string MolVolumeUnit { get; set; }
    public string MolFormula { get; set; }
    public string MolLogP { get; set; }
    public string URL { get; set; }
    public string InChI { get; set; }
    public string InChIKey { get; set; }
    public string CanonicalSmile { get; set; }
    public string IUPACName { get; set; }
    public string CommonName { get; set; }
    public string CASNumber { get; set; }
    public string PubChemRef { get; set; }

  }
}