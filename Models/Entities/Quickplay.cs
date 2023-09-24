namespace bingo_api.Models.Entities;

public class Quickplay
{
    public int QuickplayId { get; set; }
    public List<QuickplayObject> QuickplayObjects { get; set; } = null!;
    public int UserId { get; set; }
    public DateTime LastRefreshDate { get; set; }
}