using bingo_api.Models.DTOs;
using bingo_api.Models.Views;
using bingo_api.Models.Views.Responses;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services;

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

    public async Task<IEnumerable<Models.Entities.User>> GetUsers()
    {
        var result = await _context.Users
            .Include(q => q.Quickplays)
            .ThenInclude(q => q.QuickplayObject)
            .ToListAsync();
        return result;
    }

    public async Task<QuickplayScreenDto> GetUserQuickplayScreen(int userId)
    {
        var user = await _context.Users
            .Where(q => q.UserId == userId)
            .Include(user => user.LevelNumberNavigation)
            .FirstAsync();
        
        var levelWidgetDto = new LevelWidgetDto
        {
            Level = user.LevelNumber,
            Points = user.Points,
            RequiredPoints = user.LevelNumberNavigation.LevelNumber,
            Username = user.Username
        };

        List<QuickplayDto> quickplayDtos = await _context.Quickplays
            .Where(q => q.UserId == userId)
            .Include(q => q.QuickplayObject)
            .Select(q => new QuickplayDto
            {
                QuickplayId = q.QuickplayId,
                QuickplayObjectId = q.QuickplayObjectId,
                Name = q.QuickplayObject.Name,
                Points = q.QuickplayObject.Points
            }).ToListAsync();

        QuickplayScreenDto quickplayScreenDto = new QuickplayScreenDto
        {
            LevelWidgetDto = levelWidgetDto,
            Quickplays = quickplayDtos,
            UserId = userId
        };

        return quickplayScreenDto;
    }
}