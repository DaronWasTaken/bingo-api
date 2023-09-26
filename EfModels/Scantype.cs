using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Scantype
{
    public int Scantypeid { get; set; }

    public int? Locationid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Quickplayobject> Quickplayobjects { get; set; } = new List<Quickplayobject>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
