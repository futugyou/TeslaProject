using System.Net.WebSockets;
using TeslaApi.Abstractions;
using TeslaApi.Contract;

namespace TeslaApi;

public class TeslaStream : ITeslaStream
{
    // TODO: 
    public Task HandleMessage(TeslaStreamMessage message, CancellationToken cancellation)
    {
        switch (message.MsgType)
        {
            case MessageType.Hello:
                // send SubscribeOauth
                break;  
            case MessageType.Update:
                // update vehicle data
            case MessageType.WsError:
                // handle error
                break;

        }
        return Task.CompletedTask;
    }


}