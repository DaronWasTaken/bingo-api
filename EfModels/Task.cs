using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Task
{
    public int Taskid { get; set; }

    public int Achievementid { get; set; }

    public int Scanobjectid { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual Scantype Scanobject { get; set; } = null!;

    public virtual ICollection<Usertask> Usertasks { get; set; } = new List<Usertask>();
}
