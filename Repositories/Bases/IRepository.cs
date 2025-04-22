namespace SetecBackendCSharp.Repositories.Bases
{
  public interface IRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int Id);
    Task<T> Post(T entity);
    Task<T?> Put(T entity);
    void Delete(T entity);
  }
}