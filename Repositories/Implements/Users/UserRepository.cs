using SetecBackendCSharp.db.Context;
using SetecBackendCSharp.Models.Implementations.UserModel;
using SetecBackendCSharp.Repositories.Generic;

namespace SetecBackendCSharp.Repositories.Implements.Users
{
    public class UserRepository(MySQLContext context)
        : GenericRepository<User>(context), IUserRepository
    { }
}