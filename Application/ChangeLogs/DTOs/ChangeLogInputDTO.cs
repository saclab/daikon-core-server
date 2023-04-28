using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ChangeLogs.DTOs
{
  public class ChangeLogInputDTO
  {
    public string Entity { get; set; }
    public string Property { get; set; }
    public string Key { get; set; }
    public List<string> Keys { get; set; }
  }
}