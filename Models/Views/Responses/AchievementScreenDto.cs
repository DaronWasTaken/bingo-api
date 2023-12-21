namespace bingo_api.Models.DTOs;

public class AchievementScreenDto
{
    public string UserId { get; set; }
    public List<AchievementDto> Achievements { get; set; }
}