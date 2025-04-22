using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SetecBackendCSharp.Data;
using SetecBackendCSharp.Repositories.Interfaces;

namespace SetecBackendCSharp.Repositories.Bases;
public class BaseRepository<T> : IRepository<T> where T : class
{
  protected readonly ApplicationDbContext _context;
  protected readonly DbSet<T> _dbSet;

  public BaseRepository(ApplicationDbContext context)
  {
    _context = context;
    _dbSet = context.Set<T>();
  }


  void IRepository<T>.Delete(T entity) => _dbSet.Remove(entity);

  async Task<IEnumerable<T>> IRepository<T>.GetAll() => await _dbSet.ToListAsync();

  async Task<T?> IRepository<T>.GetById(int Id) => await _dbSet.FindAsync(Id);


  async Task<T> IRepository<T>.Post(T entity)
  {
    await _dbSet.AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  async Task<T?> IRepository<T>.Put(T entity)
  {
    _dbSet.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}