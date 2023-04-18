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

    /* Screening methods are used in the ongoing screens */
    public List<string> ScreeningMethods { get; set; }

    public AppCount AppCount { get; set; }

    /* Count of Domain */

    public List<Strain> Strains { get; set; }
  }
}
