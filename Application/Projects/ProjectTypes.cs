using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects
{
  public class ProjectTypes
  {
    private ProjectTypes(string value) { Value = value; }

    public string Value { get; private set; }

    public static ProjectTypes Unlinked { get { return new ProjectTypes("Unlinked"); } }
    public static ProjectTypes TargetBased { get { return new ProjectTypes("TargetBased"); } }
    public static ProjectTypes Phenotypic { get { return new ProjectTypes("Phenotypic"); } }
  }
}