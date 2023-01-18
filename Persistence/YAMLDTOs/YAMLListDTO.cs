using System.Collections.Generic;

namespace Persistence.YAMLDTOs
{
  public class YAMLListDTO<T>
  {
    public string Name { get; set; }
    public string Type { get; set; }
    public List<T> Data { get; set; }

  }
}