using AutoMapper;
using BackendSrSaude.Data.DTO.Base;
using SetecBackendCSharp.Data.VO.Base;
using SetecBackendCSharp.Models.Base;

namespace SetecBackendCSharp.Data.Mappings.Base
{
  public class BaseMapper<VO, M, DTO> : Profile where VO : BaseVO where M : BaseModel where DTO : BaseDTO
  {
    public BaseMapper()
    {
      //User
      CreateMap<M, DTO>().ReverseMap();
      CreateMap<VO, M>();
    }
  }
}
