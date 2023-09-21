namespace bingo_api.Models;

public class Level
{
    public int LevelId { get; set; }

    public int LevelNumber { get; set; }

    public int? XpRequired { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
