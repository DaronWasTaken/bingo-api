using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int Points { get; set; }

    public int LevelId { get; set; }

    public virtual Level Level { get; set; } = null!;

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
}
