using BackendSrSaude.Data.DTO.Base;
using Microsoft.AspNetCore.Mvc;
using SetecBackendCSharp.Data.DTO.Base;
using SetecBackendCSharp.Data.VO.Base;

namespace SetecBackendCSharp.Controllers.Contracts
{
    public interface IController<DTO, VO> where DTO : BaseDTO where VO : BaseVO
    {
        Task<ActionResult<CursorPagedDTO<DTO>>> GetAllPaged(long? lastId, int size);
        Task<ActionResult<DTO>> Get(long id);
        Task<ActionResult<DTO>> Post([FromBody] VO VO);
        Task<ActionResult<DTO>> Put([FromBody] VO VO);
        Task<IActionResult> Delete(long id);
    }
}