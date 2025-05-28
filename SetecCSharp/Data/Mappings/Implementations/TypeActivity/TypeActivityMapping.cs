using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.DTO.Implementations.TypeActivity;
using SetecCSharp.Data.Mappings.Base;
using SetecCSharp.Data.VO.Implementations.TypeActivity;
using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Models.Implementations.TypeActivity;

namespace SetecCSharp.Data.Mappings.Implementations.TypeActivity
{
    public class TypeActivityMapping : BaseMapper<TypeActivityVO, TypeActivityModel, TypeActivityDTO>
    {
        public TypeActivityMapping()
        {
            CreateMap<ActivityModel, ActivityDTO>();
        }
    }
}
