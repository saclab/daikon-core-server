using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizon.DTO
{
  public class HorizonTarget
  {
    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public string TargetName { get; set; }
      public string TargetType { get; set; }
      public string BucketScore { get; set; }
      public string Link { get; set; }

    }

    public Attribute Attributes { get; set; }
    public List<HorizonScreen> Children { get; set; }

    public HorizonTarget()
    {
      this.Attributes = new Attribute();
    }

  }
}