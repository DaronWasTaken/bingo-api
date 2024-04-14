using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class UserAchievement
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public int AchievementId { get; set; }

    public int CompletedSubtasks { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserSubtask> UserSubtasks { get; set; } = new List<UserSubtask>();
}
