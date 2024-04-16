using bingo_api.Models.DTOs;
using bingo_api.Models.Entities;
using bingo_api.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services;

public class UserService : IUserService
{
    private readonly PostgresContext _context;

    public UserService(PostgresContext context)
    {
        _context = context;
    }

    public async Task<LevelWidgetDto> GetUserLevelWidget(string userId)
    {
        var user = await _context.Users
            .Include(user => user.Level)
            .FirstAsync(user => user.Id.Equals(userId));

        var levelWidgetDto = new LevelWidgetDto
        {
            Level = user.LevelId,
            Points = user.Points,
            RequiredPoints = user.Level.RequiredPoints,
            Username = user.Username
        };

        return levelWidgetDto;
    }

    public async Task InitializeNewUserData(User user)
    {
        var items = await _context.Items
            .OrderBy(r => EF.Functions.Random())
            .Take(5)
            .ToListAsync();

        items.ForEach(o =>
        {
            var item = new UserItem
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                ItemId = o.Id
            };

            _context.UserItems.Add(item);
        });

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetUsersWithQuickplays()
    {
        var result = await _context.Users
            .Include(q => q.UserItems)
            .ThenInclude(q => q.Item)
            .ToListAsync();
        return result;
    }

    public async Task<QuickplayScreenDto> GetUserQuickplayScreen(string userId)
    {
        var user = await _context.Users
            .Where(q => q.Id.Equals(userId))
            .Include(user => user.Level)
            .FirstAsync();

        var levelWidgetDto = new LevelWidgetDto
        {
            Level = user.LevelId,
            Points = user.Points,
            RequiredPoints = user.Level.RequiredPoints,
            Username = user.Username
        };

        var quickplayDtos = await _context.UserItems
            .Where(q => q.UserId.Equals(userId))
            .Include(q => q.Item)
            .Select(q => new QuickplayDto
            {
                QuickplayId = q.Id,
                QuickplayObjectId = q.ItemId,
                Name = q.Item.Name,
                Points = q.Item.Points
            }).ToListAsync();

        var quickplayScreenDto = new QuickplayScreenDto
        {
            LevelWidgetDto = levelWidgetDto,
            Quickplays = quickplayDtos,
            UserId = userId
        };

        return quickplayScreenDto;
    }

    /*
     * Retrieves a user's achievement screen, indicating which achievements are achieved by the user
     */
    public async Task<AchievementScreenDto> GetUserAchievementScreen(string userId)
    {
        var achievements = await _context.Achievements
            .ToListAsync();

        var userAchievements = await _context.UserAchievements
            .Where(ua => ua.UserId == userId)
            .ToListAsync();

        var achievementDtos = new List<AchievementDto>();

        foreach (var achievement in achievements)
        {
            var userAchievement = userAchievements.FirstOrDefault(ua => ua.AchievementId == achievement.Id);

            var achievementDto = new AchievementDto
            {
                AchievementId = achievement.Id,
                Name = achievement.Name,
                Description = achievement.Description,
                Points = achievement.Points,
                DateEarned = userAchievement?.CompletionDate,
                BadgeUrl = achievement.BadgeFile,
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