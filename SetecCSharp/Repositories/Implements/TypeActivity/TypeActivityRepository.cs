using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.TypeActivity;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.TypeActivity
{
    public class TypeActivityRepository(MySQLContext context)
                : GenericRepository<TypeActivityModel>(context), ITypeActivityRepository
    { }
}