using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SetecCSharp.Models.Base;

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
        // public List<ActivityModel> Activities   new ArrayList<>();
    }
}