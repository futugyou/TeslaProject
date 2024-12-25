namespace Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddRedisExtension(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        return services.AddRedisExtension(configuration);
    }

    public static IServiceCollection AddRedisExtension(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<RedisOptions>(configuration.GetSection("RedisOptions"));
        services.AddSingleton<IRedisClient, RedisClient>();
        return services;
    }
}

public interface IRedisClient
{
    Task<bool> Lock(string key, string value, int expireMilliSeconds);
    Task<bool> UnLock(string key, string value);
}

public class RedisClient : IRedisClient
{
    private readonly IDatabase _db;

    private readonly ConnectionMultiplexer _redis;

    private const string LOCKSTRING = @"local isnx = redis.call('SETNX', @key, @value)
                                        if isnx == 1 then
                                            redis.call('PEXPIRE',@key,@time)
                                            return 1
                                        end
                                        return 0";

    private const string UNLOCKSTRING = @"local getlock = redis.call('GET', @key)
                                            if getlock == @value then
                                                redis.call('DEL', @key)
                                                return 1
                                            end
                                            return 0";

    private readonly RedisOptions _options;
    public RedisClient(IOptions<RedisOptions> option)
    {
        _options = option.Value;
        _redis = ConnectionMultiplexer.Connect(_options.Host);
        _db = _redis.GetDatabase(0);
    }

    public Task<bool> Lock(string key, string value, int expireMilliSeconds) => _options.RedisType switch
    {
        RedisDbType.garnet => CodeLock(key, value, expireMilliSeconds),
        _ => ScriptLock(key, value, expireMilliSeconds),
    };

    public Task<bool> UnLock(string key, string value) => _options.RedisType switch
    {
        RedisDbType.garnet => CodeUnLock(key, value),
        _ => ScriptUnLock(key, value),
    };

    #region private
    private async Task<bool> ScriptLock(string key, string value, int expireMilliSeconds)
    {
        var prepared = LuaScript.Prepare(LOCKSTRING);
        RedisResult redisResult = await _db.ScriptEvaluateAsync(prepared, new { key = (RedisKey)key, value = value, time = expireMilliSeconds });
        return "1".Equals(redisResult?.ToString());
    }

    private async Task<bool> ScriptUnLock(string key, string value)
    {
        var prepared = LuaScript.Prepare(UNLOCKSTRING);
        RedisResult redisResult = await _db.ScriptEvaluateAsync(prepared, new { key = (RedisKey)key, value = value });
        return "1".Equals(redisResult?.ToString());
    }

    private Task<bool> CodeLock(string key, string value, int expireMilliSeconds)
    {
        TimeSpan expirationTime = TimeSpan.FromMilliseconds(expireMilliSeconds);
        return _db.StringSetAsync(key, value, expirationTime, When.NotExists);
    }

    private Task<bool> CodeUnLock(string key, string value)
    {
        return _db.KeyDeleteAsync(key);
    }
    #endregion
}

public class RedisOptions
{
    public string Host { get; set; }
    public RedisDbType RedisType { get; set; } = RedisDbType.redis;
}
public enum RedisDbType
{
    redis,
    garnet,
}