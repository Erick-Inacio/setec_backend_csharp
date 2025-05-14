using AutoMapper;
using SetecCSharp.Data.DTO.Implementations.Event;
using SetecCSharp.Data.VO.Implementations.Event;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Repositories.Implements.Event;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Event
{
    public class EventService(IEventRepository repository, IMapper mapper)
        : GenericService<EventVO, EventModel, EventDTO>(repository, mapper), IEventService
    { }
}