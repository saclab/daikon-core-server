using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class INDDTO
  {
    public Guid Id { get; set; }
    public DateTime INDStart { get; set; }
    public string INDDescription { get; set; }
  }
}