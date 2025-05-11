using SetecCSharp.Data.VO.Base;

namespace SetecCSharp.Data.VO.Implementations.Speaker
{
    public class SpeakerVO : BaseVO
    {
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? Bio { get; set; }
        public long? UserId { get; set; }
        public string? AdminUid { get; set; }
    }
}