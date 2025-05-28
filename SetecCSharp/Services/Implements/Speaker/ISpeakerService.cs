using SetecCSharp.Data.Dto.Implementations.Speaker;
using SetecCSharp.Data.VO.Implementations.Speaker;
using SetecCSharp.Services.Bases.Generic;

namespace SetecCSharp.Services.Implements.Speaker
{
    public interface ISpeakerService : IService<SpeakerVO, SpeakerDTO>
    {
        Task<SpeakerDTO> FindSpeakerByUserId(long userId);
    }
}