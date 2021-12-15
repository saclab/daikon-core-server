using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects.DTOs
{
  public class H2LDTO
  {
    public Guid Id { get; set; }
    public DateTime H2LStart { get; set; }
    public string H2LDescription { get; set; }
  }
}