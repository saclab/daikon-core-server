using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects
{
  public class Common
  {
    public string StageGen(string stage)
    {
      switch (stage)
      {
        case "HA":
          return ProjectStage.HA.Value;
        case "H2L":
          return ProjectStage.H2L.Value;
        case "LO":
          return ProjectStage.LO.Value;
        case "SP":
          return ProjectStage.SP.Value;
        case "PC":
          return ProjectStage.PC.Value;
        case "IND":
          return ProjectStage.IND.Value;
        case "P1":
          return ProjectStage.P1.Value;
        default:
          throw new ArgumentException(
            "Invalid Project Stage", stage);
      }
    }
  }
}