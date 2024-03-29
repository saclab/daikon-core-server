using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Domain.AppConfigurations
{
  public class AppConfiguration : Metadata
  {
    public Guid Id { get; set; }
    [Required]
    public string Key { get; set; }
    [Required]
    public string Value { get; set; }
    public string Component { get; set; }
    public int Version { get; set; }
    public string Comments { get; set; }
    public bool isValueInJSON { get; set; }
    public bool isValueInYAML { get; set; }


  }
}