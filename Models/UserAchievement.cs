namespace bingo_api.Models;

public class UserAchievement
{
    public int UserAchievementId { get; set; }

    public int UserId { get; set; }

    public int AchievementId { get; set; }

    public DateTime? DateEarned { get; set; }

    public bool Completed { get; set; }

    public Achievement Achievement { get; set; } = null!;

    public User User { get; set; } = null!;
}
