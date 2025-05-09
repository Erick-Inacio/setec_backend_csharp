using AutoMapper;
using SetecBackendCSharp.Data.DTO.Implementations.User;
using SetecBackendCSharp.Data.VO.Implementations.User;
using SetecBackendCSharp.Models.Implementations.UserModel;
using SetecBackendCSharp.Repositories.Implements.Users;
using SetecBackendCSharp.Services.Generic;

namespace SetecBackendCSharp.Services.Implements.Users
{
    public class UserService(IUserRepository _repository, IMapper _mapper)
        : GenericService<UserVO, User, UserDTO>(_repository, _mapper), IUserService
    { }
}

