namespace bingo_api.Models;

public class ScanType
{
    public int ScanTypeId { get; set; }

    public int? LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<QuickplayObject> QuickplayObjects { get; set; } = new List<QuickplayObject>();

    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
