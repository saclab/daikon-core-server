using System;

namespace Domain
{
    public class Screen
    {
        public Guid Id { get; set; }
        public Target BaseTarget { get; set; }
        public Guid TargetId { get; set; }
        public string AccessionNumber { get; set; }
        public string Status { get; set; }
        
    }
}