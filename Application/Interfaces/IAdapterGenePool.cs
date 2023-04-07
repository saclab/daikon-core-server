using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IAdapterGenePool
    {
        /* Get the Adapter Name */
        string GetAdapterName();
        /* Get the Adapter Version */
        string GetAdapterVersion();

        /* Sync the Gene Pool */
        Task<List<Gene>> SyncPool(string genePoolConfigurationName);
    }
}