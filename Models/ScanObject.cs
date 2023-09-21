namespace bingo_api.Models;

public class ScanObject
{
    public int ScanObjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? LocationId { get; set; }

    public virtual ICollection<AchievementTask> AchievementTasks { get; set; } = new List<AchievementTask>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<Quickplay> QuickPlays { get; set; } = new List<Quickplay>();
}
