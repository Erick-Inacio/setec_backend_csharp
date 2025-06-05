using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.VO.Implementations.Activity;
using SetecCSharp.Services.Bases.Generic;

namespace SetecCSharp.Services.Implements.Activity
{
    public interface IActivityService : IService<ActivityVO, ActivityDTO>
    {
        Task<IEnumerable<ActivityDTO>> FindActivitiesByEvent(long eventId);
        Task<IEnumerable<ActivityDTO>> FindActivitiesByType(long eventId);
    }
}