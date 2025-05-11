using System.ComponentModel.DataAnnotations.Schema;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Implementations.User;

namespace SetecCSharp.Models.Implementations.Speaker
{
    [Table("speakers")]
    public class SpeakerModel : BaseModel
    {
        [Column("company")]
        public string? Company { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("bio")]
        public string? Bio { get; set; }

        [Column("user_id")]
        public long? UserId { get; set; }
        public UserModel? AdminAproved { get; set; }

        [Column("admin_aproved_uid")]
        public string? AdminUid { get; set; }
        public UserModel? User { get; set; }
    }
}