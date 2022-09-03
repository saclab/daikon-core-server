using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizon.DTO
{

  public class HorizonRoot
  {

    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public List<string> AccessionNumbers { get; set; }
      public string AccessionNumber { get; set; }
      public string RootName { get; set; }
      public string TargetName { get; set; }
      public string Link { get; set; }

    }

    public Attribute Attributes { get; set; }
    public List<HorizonTarget> Children { get; set; }

    public HorizonRoot()
    {
      this.Attributes = new Attribute();
    }

  }
}