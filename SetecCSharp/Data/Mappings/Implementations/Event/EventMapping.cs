using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.DTO.Implementations.Event;
using SetecCSharp.Data.Mappings.Base;
using SetecCSharp.Data.VO.Implementations.Event;
using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Models.Implementations.Event;

namespace SetecCSharp.Data.Mappings.Implementations.Event
{
    public class EventMapping : BaseMapper<EventVO, EventModel, EventDTO>
    {
        public EventMapping()
        {
            CreateMap<ActivityModel, ActivityDTO>();
        }
    }
}