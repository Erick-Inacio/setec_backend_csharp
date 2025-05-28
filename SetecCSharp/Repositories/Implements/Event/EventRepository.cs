using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Event
{
    public class EventRepository(MySQLContext context)
                : GenericRepository<EventModel>(context), IEventRepository
    { }
}