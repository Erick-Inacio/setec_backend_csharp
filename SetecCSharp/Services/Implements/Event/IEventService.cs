using SetecCSharp.Data.DTO.Implementations.Event;
using SetecCSharp.Data.VO.Implementations.Event;
using SetecCSharp.Services.Bases.Generic;

namespace SetecCSharp.Services.Implements.Event
{
    public interface IEventService : IService<EventVO, EventDTO>
    { }
}