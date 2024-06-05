namespace Domain;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellation);
}