using SetecCSharp.Models.Base;

namespace SetecCSharp.Repositories.Generic
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindAllPaged(long? lastId, int size);
        Task<T?> FindById(long id);
        Task<T?> Create(T obj);
        Task<T?> Update(T obj);
        Task Delete(long id);
        Task<bool> Exists(long id);
    }
}