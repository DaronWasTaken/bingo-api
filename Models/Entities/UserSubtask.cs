using System;
using System.Collections.Generic;

namespace bingo_api.Models.Entities;

public partial class UserSubtask
{
    public string Id { get; set; } = null!;

    public string UserAchievementId { get; set; } = null!;

    public string SubtaskId { get; set; } = null!;

    public int NumberCompleted { get; set; }

    public virtual Subtask Subtask { get; set; } = null!;

    public virtual UserAchievement UserAchievement { get; set; } = null!;
}
