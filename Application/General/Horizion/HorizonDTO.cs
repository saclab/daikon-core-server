using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.General.Horizion
{
  public class HorizonDTO
  {
    public Gene Gene { get; set; }
    public Target Target { get; set; }
    public List<Screen> Screens { get; set; }
  }
}