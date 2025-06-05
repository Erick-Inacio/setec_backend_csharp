using Microsoft.EntityFrameworkCore;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Activity
{
    public class ActivityRepository(MySQLContext context)
                : GenericRepository<ActivityModel>(context), IActivityRepository
    {
        public async Task<IEnumerable<ActivityModel?>> GetActivitiesByEvent(long eventId)
        {
            if (eventId <= 0) throw new ArgumentException("Id inválido", nameof(eventId));

            var activities = DataSet
                .Where(a => a.EventId == eventId)
                .ToListAsync();

            ArgumentNullException.ThrowIfNull(activities);

            return await activities;
        }

        public async Task<IEnumerable<ActivityModel?>> GetActivitiesByType(long typeActivityId)
        {
            if (typeActivityId <= 0)
                throw new ArgumentException("Id inválido", nameof(typeActivityId));

            var activities = DataSet
                .Where(a => a.TypeActivityId == typeActivityId)
                .ToListAsync();

            ArgumentNullException.ThrowIfNull(activities);

            return await activities;
        }
    }
}