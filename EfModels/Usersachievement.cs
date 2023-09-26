using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Usersachievement
{
    public int Userachievementid { get; set; }

    public int Userid { get; set; }

    public int Achievementid { get; set; }

    public DateTime? Dateearned { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
