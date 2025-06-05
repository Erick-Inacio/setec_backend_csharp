using SetecCSharp.Data.DTO.Implementations.Date;
using SetecCSharp.Data.VO.Implementations.Date;
using SetecCSharp.Services.Bases.Generic;

namespace SetecCSharp.Services.Implements.Date
{
    public interface IDateService : IService<DateVO, DateDTO>
    {
        Task<IEnumerable<DateDTO?>> GetDatesByActivity(long activityId); 
    }
}