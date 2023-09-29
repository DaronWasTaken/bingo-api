using bingo_api.Models.DTOs;

namespace bingo_api.Models.Views.Responses;

public class QuickplayScreenDto
{
    public int UserId { get; set; }
    public LevelWidgetDto LevelWidgetDto { get; set; }
    public List<QuickplayDto> Quickplays { get; set; }
}