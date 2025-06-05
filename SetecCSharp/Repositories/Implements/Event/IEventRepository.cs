using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Event
{
    public interface IEventRepository : IRepository<EventModel>
    {
        Task<EventModel?> FindByIdCurrentEvent(long id);
    }
}