namespace bingo_api.Models;

public class Achievement
{
    public int AchievementId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? BadgeId { get; set; }

    public int Points { get; set; }

    public virtual ICollection<AchievementTask> AchievementTasks { get; set; } = new List<AchievementTask>();

    public virtual Badge? Badge { get; set; }

    public virtual ICollection<Timely> Timelies { get; set; } = new List<Timely>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
