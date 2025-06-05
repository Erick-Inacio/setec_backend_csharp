using System.ComponentModel.DataAnnotations.Schema;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Implementations.Activity;

namespace SetecCSharp.Models.Implementations.Date
{
    [Table("date")]
    public class DateModel : BaseModel
    {
        [Column("date")]
        public DateOnly? Date { get; set; }

        [Column("fk_activity")]
        public long? ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public ActivityModel? Activity { get; set; }

        [Column("initialHour")]
        public TimeOnly? InitialHour { get; set; }

        [Column("finalHour")]
        public TimeOnly? FinalHour { get; set; }
    }
}