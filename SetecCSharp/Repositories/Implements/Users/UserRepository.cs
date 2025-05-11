using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.User;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Users
{
    public class UserRepository(MySQLContext context)
        : GenericRepository<UserModel>(context), IUserRepository
    { }
}