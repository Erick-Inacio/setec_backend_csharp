using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SetecCSharp.Data.DTO.Implementations.Event;
using SetecCSharp.Data.VO.Implementations.Event;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Repositories.Implements.Event;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Event
{
    public class EventService : GenericService<EventVO, EventModel, EventDTO>, IEventService
    {
        private readonly MySQLContext _context;
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository, IMapper mapper, MySQLContext context)
            : base(repository, mapper)
        {
            _context = context;
            _repository = repository;
        }

        public override async Task<EventDTO?> FindById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido", nameof(id));

            var model = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            ArgumentNullException.ThrowIfNull(model);

            return _mapper.Map<EventDTO>(model);

        }

        // public async Task<CurrentEventDTO?> FindByIdCurrentEvent(long id)
        // {
        //     if (id <= 0)
        //         throw new ArgumentException("Id inválido", nameof(id));

        //     var model = await _repository.FindByIdCurrentEvent(id);

        //     ArgumentNullException.ThrowIfNull(model);

        //     return _mapper.Map<CurrentEventDTO>(model);
        // }
    }
}