using SetecCSharp.Controllers.Contracts;
using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.VO.Implementations.Activity;

namespace SetecCSharp.Controllers.Implements.Activity
{
    public interface IActivityController : IController<ActivityDTO, ActivityVO> { }
}