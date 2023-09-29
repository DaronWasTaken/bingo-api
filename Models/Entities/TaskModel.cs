namespace bingo_api.Models.Entities;

public class TaskModel
{
    public int TaskId { get; set; }

    public int AchievementId { get; set; }

    public int ScanTypeId { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual ScanType ScanType { get; set; } = null!;

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
