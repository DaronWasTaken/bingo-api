using bingo_api.Models.DTOs;

namespace bingo_api.Models.Views;

public class QuickplayScreenDto
{
    public string UserId { get; set; }
    public LevelWidgetDto LevelWidgetDto { get; set; }
    public List<QuickplayDto> Quickplays { get; set; }
}