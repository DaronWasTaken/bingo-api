using bingo_api.Models;
using bingo_api.Models.DTOs;
using bingo_api.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services;

public class UserService : IUserService
{
    private readonly BingoDevContext _context;

    public UserService(BingoDevContext context)
    {
        _context = context;
    }

    public async Task<LevelWidgetDto> GetUserLevelWidget(string id)
    {
        var user = await _context.Users
            .Include(user => user.LevelNumberNavigation)
            .FirstAsync(user => user.Id.Equals(id));

        var levelWidgetDto = new LevelWidgetDto
        {
            Level = user.LevelNumber,
            Points = user.Points,
            RequiredPoints = user.LevelNumberNavigation.RequiredPoints,
            Username = user.UserName
        };

        return levelWidgetDto;
    }

    public async Task InitializeNewUserData(User user)
    {
        var quickplayObjects = await _context.QuickplayObjects
            .OrderBy(r => EF.Functions.Random())
            .Take(5)
            .ToListAsync();

        quickplayObjects.ForEach(o =>
        {
            var quickplay = new Quickplay
            {
                UserId = user.Id,
                QuickplayObjectId = o.QuickplayObjectId
            };

            _context.QuickPlays.Add(quickplay);
        });

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetUsersWithQuickplays()
    {
        var result = await _context.Users
            .Include(q => q.Quickplays)
            .ThenInclude(q => q.QuickplayObject)
            .ToListAsync();
        return result;
    }

    public async Task<QuickplayScreenDto> GetUserQuickplayScreen(string userId)
    {
        var user = await _context.Users
            .Where(q => q.Id.Equals(userId))
            .Include(user => user.LevelNumberNavigation)
            .FirstAsync();

        var levelWidgetDto = new LevelWidgetDto
        {
            Level = user.LevelNumber,
            Points = user.Points,
            RequiredPoints = user.LevelNumberNavigation.RequiredPoints,
            Username = user.UserName
        };

        var quickplayDtos = await _context.QuickPlays
            .Where(q => q.UserId.Equals(userId))
            .Include(q => q.QuickplayObject)
            .Select(q => new QuickplayDto
            {
                QuickplayId = q.QuickplayId,
                QuickplayObjectId = q.QuickplayObjectId,
                Name = q.QuickplayObject.Name,
                Points = q.QuickplayObject.Points
            }).ToListAsync();

        var quickplayScreenDto = new QuickplayScreenDto
        {
            LevelWidgetDto = levelWidgetDto,
            Quickplays = quickplayDtos,
            UserId = userId
        };

        return quickplayScreenDto;
    }

    public async Task<AchievementScreenDto> GetUserAchievementScreen(string userId)
    {
        var user = await _context.Users
            .Where(u => u.Id.Equals(userId))
            .FirstOrDefaultAsync();
        
        //retrieve all achievements and user achievements for the given user
        var achievements = await _context.Achievements
            .Include(a => a.UserAchievements)
            .Where(a => a.UserAchievements.Any(ua => ua.Userid == userId))
            .ToListAsync();

        var achievementDtos = new List<AchievementDto>();

        foreach (var achievement in achievements)
        {
            var userAchievement = achievement.UserAchievements.FirstOrDefault(ua => ua.Userid == userId);

            var achievementDto = new AchievementDto
            {
                AchievementId = achievement.AchievementId,
                Name = achievement.Name,
                Description = achievement.Description,
                Points = achievement.Points,
                DateEarned = userAchievement?.DateEarned,
                IsAchieved = userAchievement != null 
            };

            achievementDtos.Add(achievementDto);
        }

        var achievementScreenDto = new AchievementScreenDto
        {
            UserId = userId,
            Achievements = achievementDtos
        };

        return achievementScreenDto;
    }
}