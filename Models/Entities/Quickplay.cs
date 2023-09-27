namespace bingo_api.Models.Entities;

public class Quickplay
{
    public int QuickplayId { get; set; }

    public int QuickplayObjectId { get; set; }

    public int UserId { get; set; }

    public DateOnly? LastRefreshDate { get; set; }

    public virtual QuickplayObject QuickplayObject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
