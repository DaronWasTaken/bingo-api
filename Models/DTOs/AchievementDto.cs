namespace bingo_api.Models.DTOs;

public class AchievementDto
{
    public int AchievementId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Points  { get; set; }
    public string? BadgeFile { get; set; }
    public int TotalSubtasks { get; set; }
    public int CompletedSubtasks { get; set; }
    public DateTime? DateEarned { get; set; }
    public bool IsAchieved { get; set; }
    
}