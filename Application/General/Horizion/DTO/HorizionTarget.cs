using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizion.DTO
{
  public class HorizionTarget
  {
    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public string AccessionNumber { get; set; }
      public string ProteinName { get; set; }
      public string BucketScore { get; set; }

    }

    public Attribute Attributes { get; set; }
    public List<HorizionScreen> Children { get; set; }

    public HorizionTarget()
    {
      this.Attributes = new Attribute();
    }

  }
}