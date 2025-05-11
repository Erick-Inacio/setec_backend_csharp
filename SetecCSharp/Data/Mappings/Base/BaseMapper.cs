using AutoMapper;
using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.VO.Base;
using SetecCSharp.Models.Base;

namespace SetecCSharp.Data.Mappings.Base
{
    public class BaseMapper<VO, M, DTO> : Profile where VO : BaseVO where M : BaseModel where DTO : BaseDTO
    {
        public BaseMapper()
        {
            CreateMap<M, DTO>().ReverseMap();
            CreateMap<VO, M>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id.HasValue)); ;
        }
    }
}
