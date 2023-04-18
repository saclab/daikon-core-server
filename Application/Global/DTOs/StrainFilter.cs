using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Global.DTOs
{
  public class StrainFilter
  {
    public bool enabled { get; set; }
    public Guid strainId { get; set; }
  }
}