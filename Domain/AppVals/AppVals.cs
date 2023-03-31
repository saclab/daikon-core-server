using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class AppVals : Metadata
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

  }
}