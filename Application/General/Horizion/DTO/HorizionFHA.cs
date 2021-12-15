using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.General.Horizion.DTO
{
  public class HorizionFHA
  {
    public string Name { get; set; }
    public class Attribute
    {
      public Guid Id { get; set; }
      public string AccessionNumber { get; set; }
      public string ProjectName { get; set; }
      public string Status { get; set; }
      public string OrgAlias { get; set; }

    }

    public Attribute Attributes { get; set; }
    public List<HorizionPortfolio> Children { get; set; }

    public HorizionFHA()
    {
      this.Attributes = new Attribute();
    }
  }
}