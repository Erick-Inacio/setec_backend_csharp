using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Activity
{
    public interface IActivityRepository : IRepository<ActivityModel>
    {
        Task<IEnumerable<ActivityModel?>> GetActivitiesByEvent(long id);
        Task<IEnumerable<ActivityModel?>> GetActivitiesByType(long typeActivityId);
    }
}