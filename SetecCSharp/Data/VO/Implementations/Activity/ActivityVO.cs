using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Data.VO.Implementations.Activity
{
    public class ActivityVO : BaseVO
    {
        public string? Name { get; set; }
        public long? TypeActivityId { get; set; }
        public long? EventId { get; set; }
        public int? DaysQuantity { get; set; }
        public int? HoursQuantity { get; set; }
        public int? QtdeVagas { get; set; }
    }
}