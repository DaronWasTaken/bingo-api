namespace bingo_api.Models.Entities;

public class Achievement
{
    public int AchievementId { get; set; }

    public int? BadgeId { get; set; }

    public int? TimelyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Points { get; set; }

    public virtual Badge? Badge { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual Timely? Timely { get; set; }

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
