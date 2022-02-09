using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class AppVals
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

  }
}