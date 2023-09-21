namespace bingo_api.Models;

public class Badge
{
    public int BadgeId { get; set; }

    public string? Name { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
