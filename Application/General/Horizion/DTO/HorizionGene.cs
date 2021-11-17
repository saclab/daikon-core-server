using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizion.DTO
{

  public class HorizionGene
  {

    public string Name { get; set; }
    public class Attribute
    {
      public string AccessionNumber { get; set; }
      public string GeneName { get; set; }
    }

    public Attribute Attributes { get; set; }
    public List<HorizionTarget> Children { get; set; }

    public HorizionGene()
    {
      this.Attributes = new Attribute();
    }

  }
}