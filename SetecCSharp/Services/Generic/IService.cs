using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Services.Bases.Generic
{
    public interface IService<VO, DTO> where VO : BaseVO where DTO : BaseDTO
    {
        Task<IEnumerable<DTO>> FindAll();
        Task<CursorPagedDTO<DTO>> FindAllPaged(long? page, int pageSize);
        Task<DTO?> FindById(long id);
        Task<DTO?> Create(VO obj);
        Task<DTO?> Update(VO obj);
        Task Delete(long id);
    }
}