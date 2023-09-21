namespace bingo_api.Models;

public class Timely
{
    public int TimelyId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; } = null!;

    public int AchievementId { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;
}
