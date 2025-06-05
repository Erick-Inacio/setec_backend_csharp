using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Implementations.Activity;

namespace SetecCSharp.Models.Implementations.Event
{
    [Table("event")]
    public class EventModel : BaseModel
    {
        [Column("startAt")]
        public DateTime InitialDateTime { get; set; }

        [Column("endAt")]
        public DateTime FinalDateTime { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("isCurrent")]
        public bool? IsCurrent { get; set; }

        [NotMapped]
        public ICollection<ActivityModel> Activities { get; set; } = [];
    }
}