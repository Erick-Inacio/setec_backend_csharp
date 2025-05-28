using SetecCSharp.Data.DTO.Implementations.User;
using SetecCSharp.Data.Mappings.Base;
using SetecCSharp.Data.VO.Implementations.User;
using SetecCSharp.Models.Implementations.User;

namespace SetecCSharp.Data.Mappings.Implementations.Users
{
  public class UserMapping : BaseMapper<UserVO, UserModel, UserDTO> { }
}