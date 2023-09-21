namespace bingo_api.Models;

public class Quickplay
{
    public int QuickPlayId { get; set; }

    public string[] Wordset { get; set; } = null!;

    public int TimeLimit { get; set; }

    public int Points { get; set; }

    public int ScanObjectsScanObjectId { get; set; }

    public virtual ScanObject ScanObjectsScanObject { get; set; } = null!;

    public virtual ICollection<UserQuickplay> UserQuickPlays { get; set; } = new List<UserQuickplay>();
}
