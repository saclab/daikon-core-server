using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Adapter.GenePool.Mycobrowser.Configuration
{
    public class MycobrowswerAdapterGeneSyncConfiguration : IGeneSyncAdapterConfiguration
    {
        public string TempFilesDir { get; set; }
        public string GeneFileURL { get; set; }
        public string GeneFASTAFileURL { get; set; }
        public string ProteinFASTAFileURL { get; set; }
        public string StrainName { get; set; }
        
    }
}