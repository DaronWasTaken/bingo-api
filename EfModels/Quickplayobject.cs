using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Quickplayobject
{
    public int Quickplayid { get; set; }

    public int Scanobjectid { get; set; }

    public int Name { get; set; }

    public DateOnly Scandate { get; set; }

    public int Points { get; set; }

    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual Scantype Scanobject { get; set; } = null!;
}
