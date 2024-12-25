namespace Extensions;

public static class BackgroundTaskQueueExtensions
{
    public static IServiceCollection AddBackgroundTaskQueue(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        return services.AddBackgroundTaskQueue(configuration);
    }

    public static IServiceCollection AddBackgroundTaskQueue(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<TaskQueueOption>(configuration.GetSection("QueueOption"));
        services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
        return services;
    }
}

public class TaskQueueOption
{
    public int Capacity { get; set; } = 100;
    public int ExpireMilliSeconds { get; set; } = 60_000;
}

public class TaskQueueParameter
{
    public string IdentityKey { get; set; }
    public object Parameter { get; set; }
}

/// <summary>
/// https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=visual-studio#queued-background-tasks
/// </summary>
public interface IBackgroundTaskQueue
{
    ValueTask QueueBackgroundWorkItemAsync(Func<IServiceProvider, object, CancellationToken, ValueTask> workItem, TaskQueueParameter state);

    ValueTask<(Func<IServiceProvider, object, CancellationToken, ValueTask> function, TaskQueueParameter data)> DequeueAsync(CancellationToken cancellationToken);
}

public class BackgroundTaskQueue : IBackgroundTaskQueue
{
    private readonly Channel<(Func<IServiceProvider, object, CancellationToken, ValueTask>, TaskQueueParameter)> _queue;
    private readonly IRedisClient _redisClient;
    private readonly TaskQueueOption _taskQueueOption;

    public BackgroundTaskQueue(IRedisClient redisClient, IOptions<TaskQueueOption> option)
    {
        _taskQueueOption = option.Value;
        // Capacity should be set based on the expected application load and
        // number of concurrent threads accessing the queue.            
        // BoundedChannelFullMode.Wait will cause calls to WriteAsync() to return a task,
        // which completes only when space became available. This leads to backpressure,
        // in case too many publishers/calls start accumulating.
        var options = new BoundedChannelOptions(_taskQueueOption.Capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        _queue = Channel.CreateBounded<(Func<IServiceProvider, object, CancellationToken, ValueTask>, TaskQueueParameter)>(options);
        _redisClient = redisClient;
    }

    public async ValueTask QueueBackgroundWorkItemAsync(Func<IServiceProvider, object, CancellationToken, ValueTask> workItem, TaskQueueParameter state)
    {
        //TODO: need unlock
        if (!await _redisClient.Lock(state.IdentityKey, state.IdentityKey, _taskQueueOption.ExpireMilliSeconds))
        {
            return;
        }

        ArgumentNullException.ThrowIfNull(workItem);
        await _queue.Writer.WriteAsync((workItem, state));
    }

    public async ValueTask<(Func<IServiceProvider, object, CancellationToken, ValueTask>, TaskQueueParameter)> DequeueAsync(CancellationToken cancellationToken)
    {
        return await _queue.Reader.ReadAsync(cancellationToken);
    }
}