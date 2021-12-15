using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class SPDTO
  {
    public Guid Id { get; set; }
    public DateTime SPStart { get; set; }
    public string SPDescription { get; set; }
  }
}