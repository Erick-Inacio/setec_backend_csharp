using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SetecCSharp.Models.Base;

namespace SetecCSharp.Models.Implementations.Event
{
    [Table("events")]
    public class EventModel : BaseModel
    {
        [Column("initial_date_time")]
        public DateTime InitialDateTime { get; set; }
        
        [Column("final_date_time")]
        public DateTime FinalDateTime { get; set; }

        [Column("name")]
        public string? Name { get; set; }
        // public List<ActivityModel> Activities   new ArrayList<>();
    }
}