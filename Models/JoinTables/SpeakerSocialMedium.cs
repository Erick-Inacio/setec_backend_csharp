using System;
using System.Collections.Generic;

namespace SetecBackendCSharp.Models.Core;

public partial class SpeakerSocialMedia
{
    public long SpeakerId { get; set; }

    public string Platform { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual Speaker Speaker { get; set; } = null!;
}
