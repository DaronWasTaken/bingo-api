namespace bingo_api.Models;

public class Quickplay
{
    public int QuickplayId { get; set; }

    public int QuickplayObjectId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime? LastRefreshDate { get; set; }

    public DateTime? ScanDate { get; set; }

    public virtual QuickplayObject QuickplayObject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
