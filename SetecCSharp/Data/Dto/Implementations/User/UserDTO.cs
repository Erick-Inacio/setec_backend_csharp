using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Models.Enums;

namespace SetecCSharp.Data.DTO.Implementations.User
{
  public class UserDTO : BaseDTO
  {
    required public string Name { get; set; }
    required public string Uid { get; set; }
    required public string Email { get; set; }
    public string? Ra { get; set; }
    public Relationship Relationship { get; set; }
    public Role Role { get; set; }
  }
}