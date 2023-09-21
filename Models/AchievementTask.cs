namespace bingo_api.Models;

public class AchievementTask
{
    public int TaskId { get; set; }

    public int AchievementId { get; set; }

    public string? Description { get; set; }

    public int ObjectToScan { get; set; }

    public int Quantity { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual ScanObject ObjectToScanNavigation { get; set; } = null!;
}
