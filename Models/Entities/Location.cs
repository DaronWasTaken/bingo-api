using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class Location
{
    public string Id { get; set; } = null!;

    public int Radius { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();
}
