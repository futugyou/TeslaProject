using Domain;
using Microsoft.Extensions.Logging;

namespace Infrastruct;


public class UnitOfWork : IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;
    private readonly TeslaContext _teslaContext;

    public UnitOfWork(ILogger<UnitOfWork> logger, TeslaContext teslaContext)
    {
        _logger = logger;
        _teslaContext = teslaContext;
    }

    public async Task<bool> CommitAsync(CancellationToken cancellation)
    {
        try
        {
            await _teslaContext.SaveChangesAsync(cancellation);
        }
        catch (Exception ex)
        {
            _logger.LogError("commit error {Message}", ex.Message);
            return false;
        }

        return true;
    }
}