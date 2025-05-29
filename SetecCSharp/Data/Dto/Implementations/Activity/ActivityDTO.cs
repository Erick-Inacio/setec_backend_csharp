using SetecCSharp.Data.Dto.Base;

namespace SetecCSharp.Data.DTO.Implementations.Activity
{
    public class ActivityDTO : BaseDTO
    {
        public string? Name { get; set; }
        public long? TypeActivityId { get; set; }
        public string? TypeActivityName { get; set; }
        public long? EventId { get; set; }
        public string? EventName { get; set; }
        public int? DaysQuantity { get; set; }
        public int? HoursQuantity { get; set; }
        public int? QtdeVagas { get; set; }
    }
}