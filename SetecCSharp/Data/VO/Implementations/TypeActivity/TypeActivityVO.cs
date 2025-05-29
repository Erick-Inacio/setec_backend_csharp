using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Data.VO.Implementations.TypeActivity
{
    public class TypeActivityVO : BaseVO
    {
        public string? Name { get; set; }
        public bool? NeedsSubscription { get; set; }
    }
}