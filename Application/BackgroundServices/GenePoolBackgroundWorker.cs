using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.AppBackgroundTasks;
using Domain.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.BackgroundServices
{
  public class GenePoolBackgroundWorker : BackgroundService
  {

    private readonly IBackgroundQueue<GenePoolBackgroundTask> _queue;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<GenePoolBackgroundWorker> _logger;

    public GenePoolBackgroundWorker(IBackgroundQueue<GenePoolBackgroundTask> queue, IServiceScopeFactory scopeFactory,
        ILogger<GenePoolBackgroundWorker> logger)
    {
      _queue = queue;
      _scopeFactory = scopeFactory;
      _logger = logger;
      _logger.LogInformation("GenePool Background Worker has been Initiated");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      _logger.LogInformation("GenePool Background Worker is active");
      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          await Task.Delay(500, stoppingToken);
          var task = _queue.Dequeue();

          if (task == null) continue;

          _logger.LogInformation(" +++++ Gene Pool Sync Task found! Starting to process ..");

          using (var scope = _scopeFactory.CreateScope())
          {
            var publisher = scope.ServiceProvider.GetRequiredService<IGeneSynchronizer>();

            await publisher.SyncGenePool(task, stoppingToken);
          }

        }
        catch (Exception ex)
        {
          _logger.LogCritical("An error occurred when running background task. Exception: {@Exception}", ex);
        }
      }

    }
  }
}