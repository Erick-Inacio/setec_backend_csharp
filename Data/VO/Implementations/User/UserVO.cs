using SetecBackendCSharp.Data.VO.Base;

namespace SetecBackendCSharp.Data.VO.Implementations.User
{
  public class UserVO : BaseVO
  {
    public string? Uid { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Relationship? Relationship { get; set; }
    public Role? Role { get; set; }
    public string? Ra { get; set; }
  }
}