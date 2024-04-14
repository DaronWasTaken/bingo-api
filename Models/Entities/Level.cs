using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class Level
{
    public int Id { get; set; }

    public int RequiredPoints { get; set; }

    public virtual ICollection<User> Usrs { get; set; } = new List<User>();
}
