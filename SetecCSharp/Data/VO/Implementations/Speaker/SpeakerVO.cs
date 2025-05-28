using SetecCSharp.Data.VO.Base;
using SetecCSharp.Data.VO.Implementations.User;

namespace SetecCSharp.Data.VO.Implementations.Speaker
{
    public class SpeakerVO : BaseVO
    {
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? Bio { get; set; }
        public bool? IsApproved { get; set; }
        public DateOnly? DateFatecConclusion { get; set; }
        public UserVO? User { get; set; }
        public string? AdminUid { get; set; }
    }
}