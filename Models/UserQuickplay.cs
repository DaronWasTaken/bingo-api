namespace bingo_api.Models;

public class UserQuickplay
{
    public int UserQuickPlayId { get; set; }

    public bool Completed { get; set; }

    public DateTime? DateCompleted { get; set; }

    public int PointsEarned { get; set; }

    public int QuickPlayQuickPlayId { get; set; }

    public int UsersUserid { get; set; }

    public Quickplay QuickPlayQuickPlay { get; set; } = null!;

    public User UsersUser { get; set; } = null!;
}
