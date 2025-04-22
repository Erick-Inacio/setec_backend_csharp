using System;
using System.Collections.Generic;
using setec_backend_csharp.Models.Core;

namespace SetecBackendCSharp.Models.Core;

public partial class Speaker
{
    public long Id { get; set; }

    required public User User { get; set; }

    public string? Company { get; set; }

    public string? Position { get; set; }

    public string? Bio { get; set; }

    public User? AdminAproved { get; set; }

    public virtual ICollection<SpeakerSocialMedia> SpeakerSocialMedia { get; set; } = new List<SpeakerSocialMedia>();
}
