using SetecCSharp.Models.Implementations.Date;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Date
{
    public interface IDateRepository : IRepository<DateModel>
    {
        Task<IEnumerable<DateModel?>> FindByActivityId(long id);
    }
}