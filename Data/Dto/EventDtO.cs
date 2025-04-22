using System;
using System.Collections.Generic;
using SetecBackendCSharp.Models.Core;

namespace SetecBackendCSharp.Data.Dto;

public partial class Event
{
    public long Id { get; set; }

    public DateTime InitialDateTime { get; set; }

    public DateTime FinalDateTime { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
}
