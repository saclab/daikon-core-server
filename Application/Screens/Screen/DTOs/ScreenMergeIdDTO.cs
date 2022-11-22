using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Screens.DTOs
{
  public class ScreenMergeIdDTO
  {
    public Guid FirstScreenId { get; set; }
    public Guid MergeScreenId { get; set; }
  }
}