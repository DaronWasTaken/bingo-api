using bingo_api.Models.DTOs;

namespace bingo_api.Models.Views.Responses;

public class AchievementDetailsScreenDto
{
    public string UserAchievementId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public List<SubtaskDto>? Subtasks { get; set; }
}