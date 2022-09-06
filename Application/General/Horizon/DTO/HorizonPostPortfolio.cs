using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizon.DTO
{
  public class HorizonPostPortfolio
  {
    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public string TargetName { get; set; }
      public string ProjectName { get; set; }
      public string Status { get; set; }
      public string OrgAlias { get; set; }
      public string CurrentStage { get; set; }
      public string Link { get; set; }

    }

    public Attribute Attributes { get; set; }
    //public List<HorizonTarget> Children { get; set; }

    public HorizonPostPortfolio()
    {
      this.Attributes = new Attribute();
    }
  }
}