using SetecCSharp.Data.DTO.Implementations.User;
using SetecCSharp.Data.VO.Implementations.User;
using SetecCSharp.Services.Bases.Generic;

namespace SetecCSharp.Services.Implements.Users
{
    public interface IUserService : IService<UserVO, UserDTO> { }
}