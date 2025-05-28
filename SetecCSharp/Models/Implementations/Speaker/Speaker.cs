using System.ComponentModel.DataAnnotations.Schema;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Implementations.User;

namespace SetecCSharp.Models.Implementations.Speaker
{
    [Table("speaker")]
    public class SpeakerModel : BaseModel
    {
        [Column("company")]
        public string? Company { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("bio")]
        public string? Bio { get; set; }

        [Column("approved")]
        public bool? IsApproved { get; set; }

        [Column("dateFatecConclusion")]
        public DateOnly? DateFatecConclusion { get; set; }

        [Column("fk_User_id_user")]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel? User { get; set; }

        [Column("fk_Admin_Uid_Approved")]
        public string? AdminUid { get; set; }

    }
}