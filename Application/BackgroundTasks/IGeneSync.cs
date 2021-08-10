using System.Threading;
using System.Threading.Tasks;
using Domain.Tasks;

namespace Application.BackgroundTasks
{
  public interface IGeneSync
  {
    Task Sync(BTask task, CancellationToken cancellationToken = default);
  }
}