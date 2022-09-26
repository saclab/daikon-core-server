using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Target
    {
        public Guid Id { get; set; }

        public Guid StrainId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<TargetGene> TargetGenes { get; set; }

        public string Rank { get; set; }

        public double Score1 { get; set; }

        public double Score2 { get; set; }

        public double Score3 { get; set; }
        public TargetScorecard TargetScorecard { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        /*Summary*/
        public string Background { get; set; }

        public string Enablement { get; set; }

        public string Strategy { get; set; }

        public string Challenges { get; set; }
    }
}
