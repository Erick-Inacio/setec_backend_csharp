using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace SetecCSharp.Repositories.Implements.Event
{
    public class EventRepository(MySQLContext context) : GenericRepository<EventModel>(context), IEventRepository
    {
        public async Task<EventModel?> FindByIdCurrentEvent(long id)
        {
            return await DataSet
                .Include(e => e.Activities)
                .ThenInclude(a => a.TypeActivity)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}