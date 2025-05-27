using Microsoft.EntityFrameworkCore;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Base;

namespace SetecCSharp.Repositories.Generic
{
    public class GenericRepository<T>(MySQLContext _context) : IRepository<T> where T : BaseModel
    {
        private DbSet<T> DataSet => _context.Set<T>();

        //Crud Methods
        //getAll
        public virtual async Task<IEnumerable<T>> FindAll()
            => await DataSet.ToListAsync();

        //getAllPaged
        public async Task<IEnumerable<T>> FindAllPaged(long? lastId, int size)
        {
            if (DataSet == null)
                throw new InvalidOperationException("DataSet is null");
            var query = DataSet.AsNoTracking();

            if (lastId.HasValue)
            {
                query = query.Where(p => p.Id > lastId.Value);
            }

            query = query.OrderBy(p => p.Id);

            return await query.Take(size).ToListAsync();
        }

        //getById
        public async Task<T?> FindById(long id)
            => await DataSet.FindAsync(id);

        //Create
        public async Task<T?> Create(T obj)
        {
            try
            {
                await DataSet.AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update
        public async Task<T?> Update(T obj)
        {
            var result = await DataSet.FindAsync(obj.Id);

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(obj);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Delete
        public async Task Delete(long id)
        {
            var result = await DataSet.FindAsync(id); ;
            if (result == null) return;

            try
            {
                DataSet.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Pesonalized methods
        public async Task<bool> Exists(long id) => await DataSet.AnyAsync(p => p.Id.Equals(id));
    }
}