using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Data.VO.Implementations.Date
{
    public class DateVO : BaseVO
    {
        public DateOnly? Date { get; set; }
        public long? ActivityId { get; set; }
        public TimeOnly? InitialHour { get; set; }
        public TimeOnly? FinalHour { get; set; }
    }
}