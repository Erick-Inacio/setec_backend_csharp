using SetecBackendCSharp.Data.DTO.Implementations.User;
using SetecBackendCSharp.Data.VO.Implementations.User;
using SetecBackendCSharp.Services.Bases.Generic;

namespace SetecBackendCSharp.Services.Implements.Users
{
    public interface IUserService : IService<UserVO, UserDTO> { }
}