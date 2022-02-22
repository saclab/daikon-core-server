using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizon.DTO
{
  public class HorizonScreen
  {
    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public string TargetName { get; set; }
      public string ScreenName { get; set; }
      public string ScreenMethod { get; set; }

    }

    public Attribute Attributes { get; set; }
    public List<HorizonFHA> Children { get; set; }

    public HorizonScreen()
    {
      this.Attributes = new Attribute();
    }
  }
}