using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.DTO.Implementations.Activity;

namespace SetecCSharp.Data.DTO.Implementations.TypeActivity
{
    public class TypeActivityDTO : BaseDTO
    {
        public string? Name { get; set; }
        public bool? NeedsSubscription { get; set; }
        public IEnumerable<ActivityDTO>? Activities { get; set; }
    }
}