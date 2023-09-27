using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public class Badge
{
    public int BadgeId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
