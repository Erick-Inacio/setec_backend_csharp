using SetecCSharp.Controllers.Contracts;
using SetecCSharp.Data.DTO.Implementations.Event;
using SetecCSharp.Data.VO.Implementations.Event;

namespace SetecCSharp.Controllers.Implements.Event
{
    public interface IEventController : IController<EventDTO, EventVO> { }
}