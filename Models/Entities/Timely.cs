namespace bingo_api.Models.Entities;

public class Timely
{
    public int TimelyId { get; set; }

    public DateOnly StartTime { get; set; }

    public DateOnly EndTime { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
