namespace bingo_api.Models.Entities;

public class UserTask
{
    public int UserTaskId { get; set; }

    public int UserId { get; set; }

    public int TaskId { get; set; }

    public DateOnly DateCompleted { get; set; }

    public int QuantityCompleted { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
