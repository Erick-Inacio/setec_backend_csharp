using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using SetecBackendCSharp.Models.Base;

namespace SetecBackendCSharp.Models.Implementations.UserModel
{
  [Table("users")]
  public class User : BaseModel
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
