using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Adapter.GenePool
{
  public interface IGenePoolAdapter : IAdapter
  {
    public void Init(IGeneSyncAdapterConfiguration configuration);
    public Task<List<Gene>> FetchGenes();

  }
}