using System.Threading.Channels;

namespace TeslaApi.Web;

/// <summary>
/// https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=visual-studio#queued-background-tasks
/// </summary>
public interface IBackgroundTaskQueue
{
    ValueTask QueueBackgroundWorkItemAsync(Func<IServiceProvider, CancellationToken, object, ValueTask> workItem, object state);

    ValueTask<(Func<IServiceProvider, CancellationToken, object, ValueTask> function, object data)> DequeueAsync(CancellationToken cancellationToken);
}

public class BackgroundTaskQueue : IBackgroundTaskQueue
{
    private readonly Channel<(Func<IServiceProvider, CancellationToken, object, ValueTask>, object)> _queue;

    public BackgroundTaskQueue(int capacity)
    {
        // Capacity should be set based on the expected application load and
        // number of concurrent threads accessing the queue.            
        // BoundedChannelFullMode.Wait will cause calls to WriteAsync() to return a task,
        // which completes only when space became available. This leads to backpressure,
        // in case too many publishers/calls start accumulating.
        var options = new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        _queue = Channel.CreateBounded<(Func<IServiceProvider, CancellationToken, object, ValueTask>, object)>(options);
    }

    public async ValueTask QueueBackgroundWorkItemAsync(Func<IServiceProvider, CancellationToken, object, ValueTask> workItem, object state)
    {
        ArgumentNullException.ThrowIfNull(workItem);
        await _queue.Writer.WriteAsync((workItem, state));
    }

    public async ValueTask<(Func<IServiceProvider, CancellationToken, object, ValueTask>, object)> DequeueAsync(CancellationToken cancellationToken)
    {
        return await _queue.Reader.ReadAsync(cancellationToken);
    }
}