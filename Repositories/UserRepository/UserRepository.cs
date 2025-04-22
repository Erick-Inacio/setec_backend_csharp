using Microsoft.EntityFrameworkCore;
using setec_backend_csharp.Models.Core;
using SetecBackendCSharp.Data;
using SetecBackendCSharp.Models.Core;
using SetecBackendCSharp.Repositories.Bases;
using SetecBackendCSharp.Repositories.Interfaces;

namespace SetecBackendCSharp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> FindByUid(string uid)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Uid == uid);
        }
    }
}