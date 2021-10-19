using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
  public class AppUser : IdentityUser
  {
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public AppOrg Org { get; set; }
    public bool Lock { get; set; }
    public DateTime Archived { get; set; }
  }
}