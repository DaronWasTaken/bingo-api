using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Timely
{
    public int Timelyid { get; set; }

    public DateOnly Starttime { get; set; }

    public DateOnly Endtime { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
