using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public class QuickplayObject
{
    public int QuickplayId { get; set; }

    public int ScanTypeId { get; set; }

    public string Name { get; set; }

    public DateOnly ScanDate { get; set; }

    public int Points { get; set; }

    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual ScanType ScanType { get; set; } = null!;
}
