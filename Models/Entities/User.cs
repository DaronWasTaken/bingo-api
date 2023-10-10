using Microsoft.AspNetCore.Identity;

namespace bingo_api.Models;

public class User : IdentityUser
{
    public int LevelNumber { get; set; }

    public int Points { get; set; }

    public virtual Level LevelNumberNavigation { get; set; } = null!;

    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
