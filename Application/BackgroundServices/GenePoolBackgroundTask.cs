using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adapter.GenePool;
using Domain.AppConfigurations;

namespace Application.BackgroundServices
{
  public class GenePoolBackgroundTask
  {
    public Guid TaskLogId { get; set; }
    public Guid StrainId { get; set; }
    public IGenePoolAdapter Adapter { get; set; }
    public AppConfiguration AdapterConfiguration { get; set; }

  }
}