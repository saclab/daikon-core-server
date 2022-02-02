using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizion.DTO
{
  public class HorizionScreen
  {
    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public string TargetName { get; set; }
      public string ScreenName { get; set; }
     

    }

    public Attribute Attributes { get; set; }
    public List<HorizionFHA> Children { get; set; }

    public HorizionScreen()
    {
      this.Attributes = new Attribute();
    }
  }
}