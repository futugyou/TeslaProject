using TeslaApi.Abstractions;

namespace TeslaApi.Web;

public class TeslaWebSocketClient : BackgroundService
{
    private readonly ILogger<TeslaWebSocketClient> _logger;
    private readonly IServiceProvider _services;
    public IBackgroundTaskQueue TaskQueue { get; }

    public TeslaWebSocketClient(ILogger<TeslaWebSocketClient> logger, IServiceProvider services, IBackgroundTaskQueue taskQueue)
    {
        _logger = logger;
        _services = services;
        TaskQueue = taskQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"Queued Hosted Service is running.{Environment.NewLine}" +
            $"{Environment.NewLine}Tap W to add a work item to the " +
            $"background queue.{Environment.NewLine}");

        await BackgroundProcessing(stoppingToken);
        // using var scope = _services.CreateScope();
        // var teslaStream = scope.ServiceProvider.GetRequiredService<ITeslaStream>();
        // await teslaStream.StartAsync(stoppingToken);

        // while (true)
        // {
        //     if (stoppingToken.IsCancellationRequested)
        //     {
        //         break;
        //     }

        //     try
        //     {
        //         await teslaStream.ReceiveAsync(stoppingToken);
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //     }
        // }

        // await teslaStream.StopAsync(stoppingToken);
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem = await TaskQueue.DequeueAsync(_services, stoppingToken);

            try
            {
                // this is used to test tesla stream api
                // for product, we should start a SocketClient from frontend to save server resources
                Task.Run(async () => await workItem(_services, stoppingToken));
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
