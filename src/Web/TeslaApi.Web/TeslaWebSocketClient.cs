namespace TeslaApi.Web;

public class TeslaWebSocketClient : BackgroundService
{
    private readonly ILogger<TeslaWebSocketClient> _logger;
    private readonly IServiceProvider _services;
    public IBackgroundTaskQueue TaskQueue { get; }

    /// <summary>
    /// Do not use it in product.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="services"></param>
    /// <param name="taskQueue"></param>
    public TeslaWebSocketClient(ILogger<TeslaWebSocketClient> logger, IServiceProvider services, IBackgroundTaskQueue taskQueue)
    {
        _logger = logger;
        _services = services;
        TaskQueue = taskQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Queued Hosted Service is running.{Environment.NewLine}");

        await BackgroundProcessing(stoppingToken);
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem = await TaskQueue.DequeueAsync(stoppingToken);
            try
            {
                _ = Task.Run(async () => await workItem.function(_services, workItem.data.Parameter, stoppingToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing {WorkItem}.", nameof(workItem));
            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Queued Hosted Service is stopping.");
        await base.StopAsync(stoppingToken);
    }
}
