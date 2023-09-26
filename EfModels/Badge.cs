using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Badge
{
    public int Badgeid { get; set; }

    public string? Imageurl { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
