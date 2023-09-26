using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Level
{
    public int Levelnumber { get; set; }

    public int Requiredpoints { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
