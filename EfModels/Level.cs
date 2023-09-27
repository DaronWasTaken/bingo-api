using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public class Level
{
    public int LevelNumber { get; set; }

    public int RequiredPoints { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
