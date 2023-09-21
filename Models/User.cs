namespace bingo_api.Models;

public class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public int Points { get; set; }

    public int LevelId { get; set; }

    public virtual ICollection<AuthToken> AuthTokens { get; set; } = new List<AuthToken>();

    public virtual ICollection<Friendship> FriendshipUserId1Navigations { get; set; } = new List<Friendship>();

    public virtual ICollection<Friendship> FriendshipUserId2Navigations { get; set; } = new List<Friendship>();

    public virtual Level Level { get; set; } = null!;

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserQuickplay> UserQuickPlays { get; set; } = new List<UserQuickplay>();
}
