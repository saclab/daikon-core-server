using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.BackgroundTasks.Genes.DTO
{
  public class GeneSyncInitDTO
  {
    public string StrainCanonicalName { get; set; }
    public string AdapterName { get; set; }
    public string AdapterConfigurationName { get; set; }
  }
}