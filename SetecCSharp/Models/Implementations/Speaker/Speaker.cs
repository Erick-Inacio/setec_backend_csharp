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

        [Column("fk_admin")]
        public string? AdminUid { get; set; }

        [ForeignKey(nameof(Id))]
        public UserModel? User { get; set; }
    }
}