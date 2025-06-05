using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.DTO.Implementations.Activity;

namespace SetecCSharp.Data.DTO.Implementations.Event
{
    public class EventDTO : BaseDTO
    {
        public DateTime InitialDateTime { get; set; }
        public DateTime FinalDateTime { get; set; }
        public string? Name { get; set; }
        public List<ActivityDTO>? Activities { get; set; }
        public bool? IsCurrent { get; set; }
    }
}