namespace bingo_api.Models;

public class TaskEntity
{
    public int TaskId { get; set; }

    public int AchievementId { get; set; }

    public int ScantypeId { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual ScanType ScanType { get; set; } = null!;

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
