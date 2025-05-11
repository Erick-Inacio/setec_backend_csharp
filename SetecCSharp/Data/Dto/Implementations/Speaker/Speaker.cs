using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.DTO.Implementations.User;

namespace SetecCSharp.Data.Dto.Implementations.Speaker
{
    public class SpeakerDTO : BaseDTO
    {
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? Bio { get; set; }
        public UserDTO? AdminAproved { get; set; }
        public UserDTO? User { get; set; }
    }
}