using System;
using Domain;

namespace Application.Genes.DTOs
{
  public class GeneViewDTO
  {
    public Guid Id { get; set; }
    public string AccessionNumber { get; set; }
    public string GeneName { get; set; }
    public string Function { get; set; }
    public string Product { get; set; }
    public string FunctionalCategory { get; set; }
    public GenePublicDataDTO GenePublicData { get; set; }
  }
}