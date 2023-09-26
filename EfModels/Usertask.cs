using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Usertask
{
    public int Usertaskid { get; set; }

    public int Userid { get; set; }

    public int Taskid { get; set; }

    public DateOnly Datecompleted { get; set; }

    public int Quantitycompleted { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
