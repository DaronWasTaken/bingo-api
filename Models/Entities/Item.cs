using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class Item
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Points { get; set; }

    public virtual ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();

    public virtual ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
}
