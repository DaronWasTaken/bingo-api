using bingo_api.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services.User;

using Models.Entities;

public class UserService : IUserService
{
    private readonly BingoDevContext _context;

    public UserService(BingoDevContext context)
    {
        _context = context;
    }

    public async Task<LevelWidgetDto> GetUserLevelWidget(int id)
    {
        var user = await _context.Users
            .Include(user => user.LevelNumberNavigation)
            .FirstAsync(user => user.UserId == id);

        var levelWidgetDto = new LevelWidgetDto
        {
            Level = user.LevelNumber,
            Points = user.Points,
            RequiredPoints = user.LevelNumberNavigation.LevelNumber,
            Username = user.Username
        };
        
        return levelWidgetDto;
    }

    public async void AwardUserQuickplay(int userId, int quickplayObjectId)
    {
        var user = await _context.Users
            .Include(user => user.Quickplays)
            .FirstAsync(user => user.UserId == userId);
        
        var quickplay = await _context.Quickplays
            .FirstAsync(qp => qp.UserId == user.UserId && qp.QuickplayObjectId == quickplayObjectId);

        var quickplayObject = await
            _context.QuickplayObjects.FirstAsync(x => x.QuickplayObjectId == quickplay.QuickplayObjectId);
        
        user.Points += quickplayObject.Points;
        user.Quickplays.Remove(quickplay);
        await _context.SaveChangesAsync();
    }
}