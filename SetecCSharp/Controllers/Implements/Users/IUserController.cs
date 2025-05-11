using SetecCSharp.Controllers.Contracts;
using SetecCSharp.Data.DTO.Implementations.User;
using SetecCSharp.Data.VO.Implementations.User;

namespace SetecCSharp.Controllers.Implements.Users
{
    public interface IUserController : IController<UserDTO, UserVO> { }
}