namespace bingo_api.Models.Entities;

public class UserAchievement
{
    public int UserAchievementId { get; set; }

    public int UserId { get; set; }

    public int AchievementId { get; set; }

    public DateTime? DateEarned { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
