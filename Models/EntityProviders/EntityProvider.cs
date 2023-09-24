using bingo_api.Models.Entities;

namespace bingo_api.Models.EntityProviders;

public static class EntityProvider
{
    public static User User { get; set; } = new()
    {
        UserId = 1,
        Username = "James",
        Level = new Level
        {
            LevelNumber = 2,
            RequiredPoints = 3000
        },
        Points = 2300,
        QuickplayId = 1
    };

    public static Quickplay Quickplay { get; set; } = new()
    {
        QuickplayId = 1,
        QuickplayObjects = QuickplayObjectListProvider.QuickplayObjects,
        UserId = 1,
        LastRefreshDate = DateTime.Today
    };
}