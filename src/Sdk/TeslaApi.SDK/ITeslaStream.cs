using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using TeslaApi.Contract;

namespace TeslaApi.SDK;

public interface ITeslaStream
{
    Task StartAsync(StreamRequest rquest, CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
    public ChannelReader<TeslaStreamMessage> MessageReader { get; }
    public ChannelWriter<TeslaStreamMessage> MessagelWriter { get; }
}


public class TeslaStream(ClientWebSocket clientWebSocket) : ITeslaStream
{
    public string TeslaStreamUrl { get; set; } = "wss://streaming.vn.teslamotors.com/streaming";
    public string TeslaCnStreamUrl { get; set; } = "wss://streaming.vn.cloud.tesla.cn/streaming";
    private StreamRequest _rquest;
    private readonly Channel<TeslaStreamMessage> _receiveChannel = Channel.CreateUnbounded<TeslaStreamMessage>();
    private readonly Channel<TeslaStreamMessage> _sendChannel = Channel.CreateUnbounded<TeslaStreamMessage>();
    public ChannelReader<TeslaStreamMessage> MessageReader => _receiveChannel.Reader;
    public ChannelWriter<TeslaStreamMessage> MessagelWriter => _sendChannel.Writer;

    public async Task StartAsync(StreamRequest rquest, CancellationToken cancelToken = default)
    {
        _rquest = rquest;
        var tokenInfo = new TokenInfo(rquest.Token);
        if (tokenInfo.IsTokenExpiration())
        {
            throw new Exception("token is expirated");
        }

        if (tokenInfo.Locale == TokenLocal.China)
        {
            await clientWebSocket.ConnectAsync(new Uri(TeslaCnStreamUrl), cancelToken);
        }
        else
        {
            await clientWebSocket.ConnectAsync(new Uri(TeslaStreamUrl), cancelToken);
        }

        FireAndForget(Task.WhenAll(ReceiveLoop(cancelToken), SendLoop(cancelToken)));
    }

    static void FireAndForget(Task task)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                await task;
            }
            catch (Exception)
            {
            }
        });
    }

    private async Task ReceiveLoop(CancellationToken cancellation = default)
    {
        while (clientWebSocket.State == WebSocketState.Open && !cancellation.IsCancellationRequested)
        {
            var timeoutToken = new CancellationTokenSource(10000).Token;
            var stoppingToken = CancellationTokenSource.CreateLinkedTokenSource(cancellation, timeoutToken);

            var buffer = new ArraySegment<byte>(new byte[1024 * 4]);
            var receivedMessage = new StringBuilder();

            WebSocketReceiveResult result;
            do
            {
                result = await clientWebSocket.ReceiveAsync(buffer, stoppingToken.Token);
                if (buffer.Array != null)
                {
                    receivedMessage.Append(Encoding.UTF8.GetString(buffer.Array, buffer.Offset, result.Count));
                }
            }
            while (!result.EndOfMessage);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            }
            else
            {
                var message = JsonSerializer.Deserialize<TeslaStreamMessage>(receivedMessage.ToString(), JsonSerializerExtensions.CreateJsonSetting());
                if (message == null)
                {
                    continue;
                }
                await HandleMessage(message, cancellation);
            }
        }
    }

    private async Task SendLoop(CancellationToken cancellationToken = default)
    {
        while (await _sendChannel.Reader.WaitToReadAsync(cancellationToken))
        {
            var message = await _sendChannel.Reader.ReadAsync(cancellationToken);
            if (message is not null)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message, JsonSerializerExtensions.CreateJsonSetting()));
                await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, cancellationToken);
            }
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        _receiveChannel.Writer.TryComplete();
        _sendChannel.Writer.TryComplete();
        if (clientWebSocket.State == WebSocketState.Open || clientWebSocket.State == WebSocketState.CloseReceived)
        {
            await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Service stopping", cancellationToken);
        }
    }

    private async Task HandleMessage(TeslaStreamMessage message, CancellationToken cancellation)
    {
        switch (message.MsgType)
        {
            case MessageType.Hello:
                var data = new TeslaStreamMessage
                {
                    MsgType = MessageType.SubscribeOauth,
                    Tag = _rquest.VinID.ToString(),
                    Token = _rquest.Token,
                    Value = TeslaApiConst.TeslaMessageDataColumns,
                };
                await _sendChannel.Writer.WriteAsync(data, cancellation);
                break;
            default:
                await _receiveChannel.Writer.WriteAsync(message, cancellation);
                break;

        }
    }
}