using AutoMapper;
using SetecCSharp.Data.Dto.Implementations.Speaker;
using SetecCSharp.Data.VO.Implementations.Speaker;
using SetecCSharp.Models.Implementations.Speaker;
using SetecCSharp.Repositories.Implements.Speaker;
using SetecCSharp.Repositories.Implements.Users;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Speaker
{
    public class SpeakerService : GenericService<SpeakerVO, SpeakerModel, SpeakerDTO>, ISpeakerService
    {

        private readonly IUserRepository _userRepository;
        private readonly ISpeakerRepository _repository;
        private readonly IMapper _mapper;
        public SpeakerService(ISpeakerRepository repository, IMapper mapper,
            IUserRepository userRepository) : base(repository, mapper)
        {
            _userRepository = userRepository;
            _repository = repository;
            _mapper = mapper;
        }

        //Overrides
        public override async Task<SpeakerDTO?> Create(SpeakerVO obj)
        {
            ArgumentNullException.ThrowIfNull(obj.UserId);

            var user = await _userRepository.FindById(obj.UserId.Value)
                ?? throw new InvalidOperationException("Usuario não existe no banco");

            var speaker = await _repository.Create(_mapper.Map<SpeakerModel>(obj))
                ?? throw new InvalidOperationException("Falha ao criar palestrante");

            var speakerWithUser = await _repository.FindByIdWithUserAsync(speaker.Id)
                ?? throw new InvalidOperationException("Palestrante nao encontrado");

            return _mapper.Map<SpeakerDTO>(speakerWithUser);
        }

        public override async Task<SpeakerDTO?> FindById(long id)
        {
            var model = await _repository.FindByIdWithUserAsync(id)
                ?? throw new InvalidOperationException("Palestrante nao encontrado");
            return _mapper.Map<SpeakerDTO>(model);
        }

        public override async Task<SpeakerDTO?> Update(SpeakerVO obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(obj.Id);
            var model = await _repository.Update(_mapper.Map<SpeakerModel>(obj))
                ?? throw new InvalidOperationException("Palestrante nao encontrado");

            var speakerWithUser = await _repository.FindByIdWithUserAsync(model.Id)
                ?? throw new InvalidOperationException("Palestrante nao encontrado");
            return _mapper.Map<SpeakerDTO>(speakerWithUser);
        }

        //Personalized Methods
        public async Task<SpeakerDTO> FindSpeakerByUserId(long userId)
            => _mapper.Map<SpeakerDTO>(await _repository.FindSpeakerByUserId(userId));
    }
}