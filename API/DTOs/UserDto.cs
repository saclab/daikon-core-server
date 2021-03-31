using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UserDto
    {   
        public string Id { get; set; }
        
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        public IList<string> Roles { get; set; }

    }
}