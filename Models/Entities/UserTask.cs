namespace bingo_api.Models;

public class UserTask
{
    public int UserTaskid { get; set; }

    public string UserId { get; set; } = null!;

    public int TaskId { get; set; }

    public DateTime DateCompleted { get; set; }

    public int QuantityCompleted { get; set; }

    public virtual TaskEntity TaskEntity { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
