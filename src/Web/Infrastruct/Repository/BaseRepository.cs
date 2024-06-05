using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastruct;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly TeslaContext _context;
    protected readonly DbSet<T> _dbSet;
    public BaseRepository(TeslaContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task Add(T obj)
    {
        await _dbSet.AddAsync(obj);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public ValueTask<T?> GetById<K>(K id)
    {
        return _dbSet.FindAsync(id);
    }

    public async Task Remove<K>(K id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            // await _context.SaveChangesAsync();
        }
    }

    public Task Update(T obj)
    {
        _dbSet.Update(obj);
        return Task.CompletedTask;
        // await _context.SaveChangesAsync();
    }
}