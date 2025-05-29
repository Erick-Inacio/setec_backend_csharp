using SetecCSharp.Data.Dto.Implementations.Speaker;
using SetecCSharp.Data.Mappings.Base;
using SetecCSharp.Data.VO.Implementations.Speaker;
using SetecCSharp.Models.Implementations.Speaker;

namespace SetecCSharp.Data.Mappings.Implementations.Speaker
{
    public class SpeakerMapping : BaseMapper<SpeakerVO, SpeakerModel, SpeakerDTO>
    {
        public SpeakerMapping()
        {
            CreateMap<SpeakerVO, SpeakerModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User!.Id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        }
    }
}
