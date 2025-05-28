using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Data.VO.Implementations.Event
{
    public class EventVO : BaseVO
    {
        public DateTime InitialDateTime { get; set; }
        public DateTime FinalDateTime { get; set; }
        public string? Name { get; set; }
        
        // public List<ActivityModel> Activities   new ArrayList<>();
    }
}