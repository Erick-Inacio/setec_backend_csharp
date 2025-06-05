using SetecCSharp.Controllers.Contracts;
using SetecCSharp.Data.DTO.Implementations.Date;
using SetecCSharp.Data.VO.Implementations.Date;

namespace SetecCSharp.Controllers.Implements.Date
{
    public interface IDateController : IController<DateDTO, DateVO> { }
}