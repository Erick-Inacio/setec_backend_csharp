using System.ComponentModel.DataAnnotations.Schema;
using SetecCSharp.Models.Base;
using SetecCSharp.Models.Enums;

namespace SetecCSharp.Models.Implementations.User
{
  [Table("users")]
  public class UserModel : BaseModel
  {
    [Column("uid")]
    public string? Uid { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("Relationship")]
    public Relationship Relationship { get; set; }

    [Column("Role")]
    public Role Role { get; set; }

    [Column("ra")]
    public string? Ra { get; set; }
  }
}