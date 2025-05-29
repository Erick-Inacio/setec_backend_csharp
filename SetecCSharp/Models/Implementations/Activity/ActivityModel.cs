using System.ComponentModel.DataAnnotations.Schema;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Models.Implementations.TypeActivity;

namespace SetecCSharp.Models.Implementations.Activity
{
    [Table("activity")]
    public class ActivityModel : BaseModel
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("fk_type_activity")]
        public long? TypeActivityId { get; set; }
        [ForeignKey("TypeActivityId")]
        public TypeActivityModel? TypeActivity { get; set; }

        [Column("fk_event")]
        public long? EventId { get; set; }
        [ForeignKey("EventId")]
        public EventModel? Event { get; set; }

        [Column("daysQuantity")]
        public int? DaysQuantity { get; set; } = 1;

        [Column("hoursQuantity")]
        public int? HoursQuantity { get; set; } = 1;

        [Column("qtdeVagas")]
        public int? QtdeVagas { get; set; }
    }
}