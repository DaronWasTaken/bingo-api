using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class Achievement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string BadgeFile { get; set; } = null!;

    public int Points { get; set; }

    public int TotalSubtasks { get; set; }

    public virtual ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
