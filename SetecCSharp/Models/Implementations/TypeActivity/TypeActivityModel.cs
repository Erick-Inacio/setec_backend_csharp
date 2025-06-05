using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Implementations.Activity;

namespace SetecCSharp.Models.Implementations.TypeActivity
{
    [Table("type_activity")]
    public class TypeActivityModel : BaseModel
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("needsSubscription")]
        public bool? NeedsSubscription { get; set; } = false;

        [NotMapped]
        public ICollection<ActivityModel> Activities { get; set; } = [];
    }
}