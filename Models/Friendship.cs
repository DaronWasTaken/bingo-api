﻿namespace bingo_api.Models;

public class Friendship
{
    public int FriendshipId { get; set; }

    public DateTime DateAdded { get; set; }

    public int UserId1 { get; set; }

    public int UserId2 { get; set; }

    public virtual User UserId1Navigation { get; set; } = null!;

    public virtual User UserId2Navigation { get; set; } = null!;
}
