using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Genes.DTOs
{
  public class GenePublicEditDTO
  {
    public Guid Id { get; set; }
    public string AccessionNumber { get; set; }
    public string GeneName { get; set; }
    public string Function { get; set; }
    public string Product { get; set; }
    public string FunctionalCategory { get; set; }
    public GenePublicData GenePublicData { get; set; }
  }
}