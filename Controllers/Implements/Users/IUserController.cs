using SetecBackendCSharp.Controllers.Contracts;
using SetecBackendCSharp.Data.DTO.Implementations.User;
using SetecBackendCSharp.Data.VO.Implementations.User;

namespace SetecBackendCSharp.Controllers.Implements.Users
{
    public interface IUserController : IController<UserDTO, UserVO> { }
}