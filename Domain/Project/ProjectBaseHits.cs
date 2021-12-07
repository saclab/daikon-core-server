using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ProjectBaseHits
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        //public Project BaseProject { get; set; }
        public Guid HitId { get; set; }
        public Hit BaseHit { get; set; }
    }
}