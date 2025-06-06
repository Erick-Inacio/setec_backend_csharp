using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.Mappings.Base;
using SetecCSharp.Data.VO.Implementations.Activity;
using SetecCSharp.Models.Implementations.Activity;

namespace SetecCSharp.Data.Mappings.Implementations.Activity
{
    public class ActivityMapping : BaseMapper<ActivityVO, ActivityModel, ActivityDTO>
    {
        public ActivityMapping()
        {
            CreateMap<ActivityModel, ActivityDTO>()
                .ForMember(dest => dest.TypeActivityName, opt => opt.MapFrom(src => src.TypeActivity!.Name))
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event!.Name));

        }
    }
}
