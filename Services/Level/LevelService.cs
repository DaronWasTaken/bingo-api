using bingo_api.Models.Entities;

namespace bingo_api.Services;

public class LevelService : ILevelService
{
    private readonly PostgresContext _context;
    
    public LevelService(PostgresContext context)
    {
        _context = context;
    }

    public async Task AssignPointsToUser(User user, int points)
    {
        user.Points += points;
        var pointsSurplus = user.Points - user.Level.RequiredPoints;
        if (pointsSurplus >= 0)
        {
            if (await _context.Levels.FindAsync(user.LevelId + 1) != null)
            {
                user.LevelId += 1;
                user.Points = pointsSurplus;
            }
            else
            {
                user.Points = user.Level.RequiredPoints;
            }
        }
    }
}