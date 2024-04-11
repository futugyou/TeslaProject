using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        while (true)
        {
            ClientWebSocket webSocket = null;

            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri("wss://streaming.vn.teslamotors.com/streaming/"), CancellationToken.None);
                await Receive(webSocket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
                Console.WriteLine();
            }
        }
    }

    private async Task Send(ClientWebSocket webSocket, TeslaStreamMessage message)
    {
        try
        {
            if (webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message, JsonSerializerExtensions.CreateJsonSetting()));

                await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
                string res = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                _logger.LogInformation(res);
                await Task.Delay(1000);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

    }

    private async Task Receive(ClientWebSocket webSocket)
    {
        byte[] buffer = new byte[1024];
        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
            else
            {
                string res = Encoding.UTF8.GetString(buffer, 0, result.Count);
                _logger.LogInformation(res);
                var message = JsonSerializer.Deserialize<TeslaStreamMessage>(res, JsonSerializerExtensions.CreateJsonSetting());
                if (message?.MsgType == MessageType.Hello)
                {
                    await Send(webSocket, new TeslaStreamMessage
                    {
                        MsgType = MessageType.SubscribeOauth,
                        Tag = "fake-tag-1126116947848350",
                        Token = "fake-token-DC.eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJvcmdfaWQiOjI5NTM3NjU3OTk0LCJqdGkiOjcyNTQ3OTY0NTUxNzgyMzEzNzJ9.LWi3JiOfc_wl54880fmwEUJzwwsKCI5xkO3EPlj40lM",
                        Value = TeslaApiConst.TeslaMessageDataColumns,
                    });
                }
            }
        }
    }
}

