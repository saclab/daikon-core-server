using System;
using System.Threading;
using System.Threading.Tasks;
using Application.BackgroundTasks;
using Application.Interfaces;
using Domain.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Core
{
  public class BackgroundWorker : BackgroundService
  {

    private readonly IBackgroundQueue<BTask> _queue;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<BackgroundWorker> _logger;

    public BackgroundWorker(IBackgroundQueue<BTask> queue, IServiceScopeFactory scopeFactory,
        ILogger<BackgroundWorker> logger)
    {
      _queue = queue;
      _scopeFactory = scopeFactory;
      _logger = logger;
      Console.WriteLine(">>>  +++++ BackgroundWorker Constructor(): "); 
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      Console.WriteLine(">>>  +++++ BackgroundWorker ExecuteAsync(): "); 
      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          await Task.Delay(500, stoppingToken);
          var task = _queue.Dequeue();

          if (task == null) continue;

          _logger.LogInformation(" +++++ Task found! Starting to process ..");
          Console.WriteLine(">>>  +++++ Task found! Starting to process ..: "); 
          // TODO
          if (task.Type == "GeneSync")
          {

            using (var scope = _scopeFactory.CreateScope())
            {
              var publisher = scope.ServiceProvider.GetRequiredService<IGeneSync>();

              await publisher.Sync(task, stoppingToken);
            }

          }


        }
        catch (Exception ex)
        {
          _logger.LogCritical("An error occurred when publishing a book. Exception: {@Exception}", ex);
        }
      }

    }
  }
}