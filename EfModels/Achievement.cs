using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Achievement
{
    public int Achievementid { get; set; }

    public int? Badgeid { get; set; }

    public int? Timelyid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Points { get; set; }

    public virtual Badge? Badge { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual Timely? Timely { get; set; }

    public virtual ICollection<Usersachievement> Usersachievements { get; set; } = new List<Usersachievement>();
}
