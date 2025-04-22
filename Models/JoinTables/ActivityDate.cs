using System;
using System.Collections.Generic;

namespace SetecBackendCSharp.Models.Core;

public partial class ActivityDate
{
    public long ActivityId { get; set; }

    public DateTime Date { get; set; }

    public virtual Activity Activity { get; set; } = null!;
}
