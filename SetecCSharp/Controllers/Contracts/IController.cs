using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Controllers.Contracts
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