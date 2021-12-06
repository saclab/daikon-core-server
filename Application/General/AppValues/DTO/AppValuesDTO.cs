using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.General.AppValues.DTO
{
  public class AppValuesDTO
  {
    public List<string> AppOrgsFlattened { get; set; }
    public List<string> AppOrgsAliasFlattened { get; set; }
    public List<AppOrg> AppOrgs { get; set; }
    public List<string> AppUsersFlattened { get; set; }

  }
}