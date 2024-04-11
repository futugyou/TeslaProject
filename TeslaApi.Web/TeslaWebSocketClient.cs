using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TeslaApi.Abstractions;
using TeslaApi.Contract;

namespace TeslaApi.Web;

public class TeslaWebSocketClient : BackgroundService
{
    private readonly ILogger<TeslaWebSocketClient> _logger;
    private readonly IServiceProvider _services;

    public TeslaWebSocketClient(ILogger<TeslaWebSocketClient> logger, IServiceProvider services)
    {
        _logger = logger;
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _services.CreateScope();
        var teslaStream = scope.ServiceProvider.GetRequiredService<ITeslaStream>();
        await teslaStream.StartAsync(stoppingToken);

        while (true)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                break;
            }

            try
            {
                await teslaStream.ReceiveAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        await teslaStream.StopAsync(stoppingToken);
    }
}
