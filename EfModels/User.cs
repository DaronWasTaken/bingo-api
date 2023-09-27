﻿using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public class User
{
    public int UserId { get; set; }

    public int LevelNumber { get; set; }

    public string Username { get; set; } = null!;

    public int Points { get; set; }

    public virtual Level LevelNumberNavigation { get; set; } = null!;

    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual ICollection<UserAchievement> UsersAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
