namespace bingo_api.Models.Views.Responses;

public class LevelWidgetDto
{
    public string Username { get; set; } = null!;
    public int Level { get; set; }
    public int Points { get; set; }
    public int RequiredPoints { get; set; }
}