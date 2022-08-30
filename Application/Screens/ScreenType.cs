using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Screens
{
  public class ScreenType
  {
    private ScreenType(string value) { Value = value; }

    public string Value { get; private set; }

    public static ScreenType TargetBased { get { return new ScreenType("TargetBased"); } }
    public static ScreenType Phenotypic { get { return new ScreenType("Phenotypic"); } }

  }
}