namespace bingo_api.Models.Views;

public class LevelWidgetDto
{
    public string Username { get; set; } = null!;
    public int Level { get; set; }
    public int Points { get; set; }
    public int RequiredPoints { get; set; }
}