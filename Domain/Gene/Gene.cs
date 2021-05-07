using System;

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
    //public GenePublicData GenePublicData { get; set; } = new GenePublicData();
    //public GeneNonPublicData GeneNonPublicData { get; set; } = new GeneNonPublicData();

  }
}