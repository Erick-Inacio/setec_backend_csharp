using System;
using System.Collections.Generic;
using setec_backend_csharp.Models.Core;
using SetecBackendCSharp.Models.Core;

namespace SetecBackendCSharp.Data.Dto;

public partial class Speaker
{
  public long Id { get; set; }

  required public UserDto UserDto { get; set; }

  public string? Company { get; set; }

  public string? Position { get; set; }

  public string? Bio { get; set; }

  public UserDto? AdminAproved { get; set; }

  public virtual ICollection<SpeakerSocialMedia> SpeakerSocialMedia { get; set; } = new List<SpeakerSocialMedia>();
}
