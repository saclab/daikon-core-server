using System.Threading;
using System.Threading.Tasks;
using Domain.Tasks;

namespace Application.BackgroundTasks.GeneSync
{
  public interface IGeneSync
  {
    Task Sync(BTask task, CancellationToken cancellationToken = default);
  }
}