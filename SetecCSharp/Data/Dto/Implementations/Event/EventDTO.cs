using SetecCSharp.Data.Dto.Base;

namespace SetecCSharp.Data.DTO.Implementations.Event
{
    public class EventDTO : BaseDTO
    {
        public DateTime InitialDateTime { get; set; }
        public DateTime FinalDateTime { get; set; }
        public string? Name { get; set; }
        
        // public List<ActivityModel> Activities   new ArrayList<>();
    }
}