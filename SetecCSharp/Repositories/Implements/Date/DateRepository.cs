using Microsoft.EntityFrameworkCore;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Date;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Date
{
    public class DateRepository(MySQLContext context)
        : GenericRepository<DateModel>(context), IDateRepository
    {
        public async Task<IEnumerable<DateModel?>> FindByActivityId(long activityId)
        {
            if (activityId <= 0)
                throw new ArgumentException("Id inválido", nameof(activityId));

            var dates = DataSet
            .Where(a => a.ActivityId == activityId)
            .ToListAsync();

            ArgumentNullException.ThrowIfNull(dates);

            return await dates;
        }
    }
}