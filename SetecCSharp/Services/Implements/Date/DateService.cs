using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SetecCSharp.Data.DTO.Implementations.Date;
using SetecCSharp.Data.VO.Implementations.Date;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Date;
using SetecCSharp.Repositories.Generic;
using SetecCSharp.Repositories.Implements.Date;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Date
{
    public class DateService : GenericService<DateVO, DateModel,
            DateDTO>, IDateService
    {
        private readonly MySQLContext _context;
        private readonly IDateRepository _repository;
        public DateService(IDateRepository repository, IMapper mapper, MySQLContext context) : base(repository, mapper)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<IEnumerable<DateDTO?>> GetDatesByActivity(long activityId)
        {
            if (activityId <= 0)
                throw new ArgumentException("Id inválido", nameof(activityId));

            var dates = await _repository.FindByActivityId(activityId);

            return _mapper.Map<IEnumerable<DateDTO>>(dates);
        }
    }
}