using AutoMapper;
using SetecCSharp.Data.DTO.Implementations.User;
using SetecCSharp.Data.VO.Implementations.User;
using SetecCSharp.Models.Implementations.User;
using SetecCSharp.Repositories.Implements.Users;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Users
{
    public class UserService(IUserRepository _repository, IMapper _mapper)
        : GenericService<UserVO, UserModel, UserDTO>(_repository, _mapper), IUserService
    { }
}

