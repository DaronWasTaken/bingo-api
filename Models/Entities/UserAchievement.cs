namespace bingo_api.Models;

public class UserAchievement
{
    public int UserAchievementId { get; set; }

    public string Userid { get; set; } = null!;

    public int AchievementId { get; set; }

    public DateTime? DateEarned { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
