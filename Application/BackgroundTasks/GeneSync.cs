using System.Threading;
using System.Threading.Tasks;
using Domain.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundTasks
{
  public class GeneSync : IGeneSync
  {
    private readonly ILogger<GeneSync> _logger;

    public GeneSync(ILogger<GeneSync> logger)
    {
      _logger = logger;
    }

    public async Task Sync(BTask task, CancellationToken cancellationToken = default)
    {
      _logger.LogInformation("Doing heavy Gene Syncing logic ...");

      await Task.Delay(2500, cancellationToken);

      _logger.LogInformation("\"{id} by {type}\" has been completed!", task.Id, task.Type);
    }
  }
}