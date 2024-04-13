namespace Domain;

public interface IRepository<T> where T : class
{
    Task Add(T obj);
    ValueTask<T?> GetById<K>(K id);
    IQueryable<T> GetAll();
    Task Update(T obj);
    Task Remove<K>(K id);
}