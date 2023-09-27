namespace bingo_api.Models.Entities;

public class Level
{
    public int LevelNumber { get; set; }

    public int RequiredPoints { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
