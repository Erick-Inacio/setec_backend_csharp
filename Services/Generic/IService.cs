using BackendSrSaude.Data.DTO.Base;
using SetecBackendCSharp.Data.DTO.Base;
using SetecBackendCSharp.Data.VO.Base;

namespace SetecBackendCSharp.Services.Bases.Generic
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