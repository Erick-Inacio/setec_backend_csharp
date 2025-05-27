using Microsoft.EntityFrameworkCore;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.User;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Users
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> FindByUid(string uid)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Uid == uid);

            return user?.Id
                ?? throw new InvalidOperationException("User nao encontrado");
        }

    }
}