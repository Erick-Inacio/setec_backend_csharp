using AutoMapper;
using FirebaseAdmin.Auth;
using SetecCSharp.Data.DTO.Implementations.User;
using SetecCSharp.Data.VO.Implementations.User;
using SetecCSharp.Models.Implementations.User;
using SetecCSharp.Repositories.Implements.Users;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Users
{
    public class UserService : GenericService<UserVO, UserModel, UserDTO>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            // _mapper = mapper;
        }

        public override async Task<UserDTO?> Create(UserVO obj)
        {
            UserModel user = null!;
            try
            {
                user = await _repository.Create(_mapper.Map<UserModel>(obj))
                    ?? throw new InvalidOperationException("Falha ao criar usuario");

                //! descomentar apos teste
                // await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(user.Uid, new Dictionary<string, object>
                //     {
                //         { "userId", user.Id },
                //         { "role", user.Role.ToString() },
                //     });

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception)
            {
                if (user != null)
                {
                    await _repository.Delete(user.Id);
                    // await FirebaseAuth.DefaultInstance.DeleteUserAsync(user.Uid);
                }
                throw;
            }
        }

    }
}

