using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class UserItem
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
