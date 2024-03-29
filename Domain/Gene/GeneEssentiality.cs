using System;
using Domain.Core;

namespace Domain
{
  public class GeneEssentiality : Metadata
  {
    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Classification { get; set; }
    public string Condition { get; set; }
    public string Strain { get; set; }
    public string Method { get; set; }
    public string Reference { get; set; }
    public string URL { get; set; }
    public string Notes { get; set; }

  }
}