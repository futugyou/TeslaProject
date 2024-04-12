using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using TeslaApi.Abstractions;
using TeslaApi.Contract;

namespace TeslaApi;

public class TeslaStream : ITeslaStream
{
    private readonly ClientWebSocket _webSocket;

    public TeslaStream(ClientWebSocket webSocket)
    {
        _webSocket = webSocket;
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        await _webSocket.ConnectAsync(new Uri(TeslaApiConst.TESLA_STREAM_URL), cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseReceived)
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Service stopping", cancellationToken);
        }
    }

    public async Task SendAsync(TeslaStreamMessage message, CancellationToken cancellationToken = default)
    {
        if (_webSocket.State == WebSocketState.Open)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message, JsonSerializerExtensions.CreateJsonSetting()));
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, cancellationToken);
        }
    }

    // TODO: 
    public async Task ReceiveAsync(CancellationToken cancellation = default)
    {
        byte[] buffer = new byte[1024];
        while (_webSocket.State == WebSocketState.Open && !cancellation.IsCancellationRequested)
        {
            var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellation);
            }
            else
            {
                string res = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var message = JsonSerializer.Deserialize<TeslaStreamMessage>(res, JsonSerializerExtensions.CreateJsonSetting());
                if (message == null)
                {
                    continue;
                }

                await HandleMessage(message, cancellation);
            }
        }

        return;
    }

    private async Task HandleMessage(TeslaStreamMessage message, CancellationToken cancellation)
    {
        switch (message.MsgType)
        {
            case MessageType.Hello:
                // send SubscribeOauth
                // TODO: get data
                var data = new TeslaStreamMessage
                {
                    MsgType = MessageType.SubscribeOauth,
                    Tag = "fake-tag-1126116947848350",
                    Token = "fake-token-DC.eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJvcmdfaWQiOjI5NTM3NjU3OTk0LCJqdGkiOjcyNTQ3OTY0NTUxNzgyMzEzNzJ9.LWi3JiOfc_wl54880fmwEUJzwwsKCI5xkO3EPlj40lM",
                    Value = TeslaApiConst.TeslaMessageDataColumns,
                };
                await SendAsync(data, cancellation);
                break;
            case MessageType.Update:
            // update vehicle data
            case MessageType.WsError:
                // handle error
                break;

        }
    }
}