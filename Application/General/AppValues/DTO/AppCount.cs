using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.General.AppValues.DTO
{
    public class AppCount
    {
        public int GeneCount { get; set; }

        public int TargetCount { get; set; }

        public int ScreenCount { get; set; }

        public int FHACount { get; set; }

        public int PortfolioCount { get; set; }

        public int PostPortfolioCount { get; set; }

        /* Count of Domain */
    }
}
