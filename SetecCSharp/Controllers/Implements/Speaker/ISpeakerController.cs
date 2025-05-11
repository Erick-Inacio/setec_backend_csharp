using SetecCSharp.Controllers.Contracts;
using SetecCSharp.Data.Dto.Implementations.Speaker;
using SetecCSharp.Data.VO.Implementations.Speaker;

namespace SetecCSharp.Controllers.Implements.Speaker
{
    public interface ISpeakerController : IController<SpeakerDTO, SpeakerVO> { }
}