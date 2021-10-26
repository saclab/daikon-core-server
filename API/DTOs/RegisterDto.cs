using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
  public class RegisterDto
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string DisplayName { get; set; }
    [Required]
    public Guid OrgId { get; set; }
    public string Bio { get; set; }
    [Required]
    public IList<string> Roles { get; set; }
    public bool Lock { get; set; }


  }
}