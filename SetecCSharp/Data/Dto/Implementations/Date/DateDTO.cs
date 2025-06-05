using SetecCSharp.Data.Dto.Base;

namespace SetecCSharp.Data.DTO.Implementations.Date
{
    public class DateDTO : BaseDTO
    {
        public DateOnly? Date { get; set; }
        public long? ActivityId { get; set; }
        public TimeOnly? InitialHour { get; set; }
        public TimeOnly? FinalHour { get; set; }
    }
}