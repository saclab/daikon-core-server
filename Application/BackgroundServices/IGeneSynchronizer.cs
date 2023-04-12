using System.Threading;
using System.Threading.Tasks;
using Domain.AppBackgroundTasks;
using Domain.Tasks;

namespace Application.BackgroundServices
{
  public interface IGeneSynchronizer
  {
    Task SyncGenePool(GenePoolBackgroundTask task, CancellationToken cancellationToken = default);
  }
}