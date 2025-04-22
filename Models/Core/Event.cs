using System;
using System.Collections.Generic;

namespace SetecBackendCSharp.Models.Core;

public partial class Event
{
    public long Id { get; set; }

    public DateTime InitialDateTime { get; set; }

    public DateTime FinalDateTime { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
