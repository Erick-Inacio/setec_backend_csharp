using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Activity
{
    public class ActivityRepository(MySQLContext context)
                : GenericRepository<ActivityModel>(context), IActivityRepository
    { }
}