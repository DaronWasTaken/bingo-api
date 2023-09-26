using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Quickplay
{
    public int Quickplayid { get; set; }

    public int Quickplayobjectid { get; set; }

    public int Userid { get; set; }

    public DateOnly? Lastrefreshdate { get; set; }

    public virtual Quickplayobject Quickplayobject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
