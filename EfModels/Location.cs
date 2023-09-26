using System;
using System.Collections.Generic;

namespace bingo_api.EfModels;

public partial class Location
{
    public int Locationid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal Radius { get; set; }

    public virtual ICollection<Scantype> Scantypes { get; set; } = new List<Scantype>();
}
