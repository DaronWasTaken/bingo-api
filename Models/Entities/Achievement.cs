namespace bingo_api.Models;

public class Achievement
{
    public int AchievementId { get; set; }

    public int? BadgeId { get; set; }

    public int? TimelyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Points { get; set; }

    public virtual Badge? Badge { get; set; }

    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

    public virtual Timely? Timely { get; set; }

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
