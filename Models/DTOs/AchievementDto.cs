namespace bingo_api.Models.DTOs;

public class AchievementDto
{
    public int AchievementId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Points  { get; set; }
    public string? BadgeUrl { get; set; }
    public DateOnly? DateEarned { get; set; }
    public Boolean IsAchieved { get; set; }
    
}