using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class User
{
    public int Userid { get; set; }

    public int Levelnumber { get; set; }

    public string Username { get; set; } = null!;

    public int Points { get; set; }

    public virtual Level LevelnumberNavigation { get; set; } = null!;

    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual ICollection<Usersachievement> Usersachievements { get; set; } = new List<Usersachievement>();

    public virtual ICollection<Usertask> Usertasks { get; set; } = new List<Usertask>();
}
