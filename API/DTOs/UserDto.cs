using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace API.DTOs
{
  public class UserDto
  {
    public string Id { get; set; }

    public string DisplayName { get; set; }

    [Required]
    public string Email { get; set; }

    public IList<string> Roles { get; set; }
    public string Bio { get; set; }
    public AppOrg Org { get; set; }
    public bool Lock { get; set; }
    public DateTime Archived { get; set; }

  }
}