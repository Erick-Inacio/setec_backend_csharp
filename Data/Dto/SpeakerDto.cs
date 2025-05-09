
using SetecBackendCSharp.Data.DTO.Implementations.User;

namespace SetecBackendCSharp.Data.DTO;

public partial class Speaker
{
  public long Id { get; set; }

  required public UserDTO UserDTO { get; set; }

  public string? Company { get; set; }

  public string? Position { get; set; }

  public string? Bio { get; set; }

  public UserDTO? AdminAproved { get; set; }

  // public virtual ICollection<SpeakerSocialMedia> SpeakerSocialMedia { get; set; } = new List<SpeakerSocialMedia>();
}
