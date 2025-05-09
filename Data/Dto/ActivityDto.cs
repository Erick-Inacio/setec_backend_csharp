namespace SetecBackendCSharp.Data.DTO;

public partial class ActivityDTO
{
    public long Id { get; set; }

    required public Event Event { get; set; }

    public ActivityType ActivityType { get; set; }

    public string ActivityName { get; set; } = null!;

    public int? Duration { get; set; }

    public string? Local { get; set; }

    public string? AimedAudience { get; set; }

    public string? Prerequisite { get; set; }

    public string? HardSoftwareRequired { get; set; }

    public string? Description { get; set; }

    public bool Approved { get; set; }

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
}
