using System;
using System.Collections.Generic;

namespace Domain
{
    public class AppOrg
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        
    }
}