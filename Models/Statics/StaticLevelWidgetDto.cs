using bingo_api.Models.DTO;
using bingo_api.Models.Views;

namespace bingo_api.Models.Statics;

public static class StaticLevelWidgetDto
{
    public static LevelWidgetDto LevelWidgetDto = new()
    {
        Username = "James",
        Points = 2300,
        RequiredPoints = 3000,
        Level = 3
    };
}