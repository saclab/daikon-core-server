using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Compounds.DTOs
{
  public class CompoundEditDTO
  {
    public Guid Id { get; set; }
    public String Smiles { get; set; }
    public string MolWeight { get; set; }
    public string MolArea { get; set; }

  }
}