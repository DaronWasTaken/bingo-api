namespace bingo_api.Models.Entities;

public partial class Subtask
{
    public string Id { get; set; } = null!;

    public int AchievementId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int TotalNumber { get; set; }

    public string? ItemId { get; set; }

    public string? LocationId { get; set; }

    public string? ImageFile { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual Item? Item { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<UserSubtask> UserSubtasks { get; set; } = new List<UserSubtask>();
}
