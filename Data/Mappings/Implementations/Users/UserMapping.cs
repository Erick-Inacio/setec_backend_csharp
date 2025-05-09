using SetecBackendCSharp.Data.DTO.Implementations.User;
using SetecBackendCSharp.Data.Mappings.Base;
using SetecBackendCSharp.Data.VO.Implementations.User;
using SetecBackendCSharp.Models.Implementations.UserModel;

namespace SetecBackendCSharp.Data.Mappings.Implementations.Users
{
  public class UserMapping : BaseMapper<UserVO, User, UserDTO> { }
}