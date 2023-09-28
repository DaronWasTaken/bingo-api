using bingo_api.Models.Entities;

namespace bingo_api.Services;

public class LevelService : ILevelService
{
    private readonly BingoDevContext _context;
    
    public LevelService(BingoDevContext context)
    {
        _context = context;
    }

    public async Task AssignPointsToUser(User user, int points)
    {
        user.Points += points;
        var pointsSurplus = user.Points - user.LevelNumberNavigation.RequiredPoints;
        if (pointsSurplus > 0)
        {
            if (await _context.Levels.FindAsync(user.LevelNumber + 1) != null)
            {
                user.LevelNumber += 1;
                user.Points = pointsSurplus;
            }
            else
            {
                user.Points = user.LevelNumberNavigation.RequiredPoints;
            }
        }
    }
}