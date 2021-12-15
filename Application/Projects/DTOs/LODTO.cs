using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class LODTO
  {
    public Guid Id { get; set; }
    public DateTime LOStart { get; set; }
    public string LODescription { get; set; }
  }
}