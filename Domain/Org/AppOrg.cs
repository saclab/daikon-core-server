using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain
{
  public class AppOrg : Metadata
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public string Address { get; set; }

  }
}