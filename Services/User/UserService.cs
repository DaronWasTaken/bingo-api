﻿using bingo_api.Models.DTOs;
using bingo_api.Models.Entities;
using bingo_api.Models.Views;
using bingo_api.Models.Views.Responses;
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

        await _context.Achievements
            .Include(a => a.Subtasks)
            .ForEachAsync(async a =>
            {
                var userAchievementId = Guid.NewGuid().ToString();
                await _context.UserAchievements.AddAsync(new UserAchievement
                {
                    Id = userAchievementId,
                    UserId = user.Id,
                    AchievementId = a.Id,
                    CompletedSubtasks = 0,
                    CompletionDate = null
                });
                
                foreach (var subtask in a.Subtasks)
                {
                    await _context.UserSubtasks.AddAsync(new UserSubtask
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserAchievementId = userAchievementId,
                        SubtaskId = subtask.Id,
                        NumberCompleted = 0
                    });
                }
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
        var userAchievements = await _context.UserAchievements
            .Where(ua => ua.UserId == userId)
            .Include(ua => ua.Achievement)
            .Select(ua => new AchievementDto
            {
                AchievementId = ua.AchievementId,
                Name = ua.Achievement.Name,
                Description = ua.Achievement.Description,
                Points = ua.Achievement.Points,
                TotalSubtasks = ua.Achievement.TotalSubtasks,
                CompletedSubtasks = ua.CompletedSubtasks,
                BadgeFile = ua.Achievement.BadgeFile,
                IsAchieved = ua.Achievement.TotalSubtasks - ua.CompletedSubtasks == 0,
                DateEarned = ua.CompletionDate
            })
            .ToListAsync();

        return new AchievementScreenDto
        {
            UserId = userId,
            Achievements = userAchievements
        };
    }

    public async Task<AchievementDetailsScreenDto> GetUserAchievementDetailsScreen(string userId, int achievementId)
    {
        var achievementDetailsScreenDto = await _context.UserAchievements
            .Include(ua => ua.Achievement)
            .Where(ua => ua.AchievementId == achievementId && ua.UserId == userId)
            .Select(ua => new AchievementDetailsScreenDto
            {
                UserAchievementId = ua.Id,
                Name = ua.Achievement.Name,
                Description = ua.Achievement.Description,
                Points = ua.Achievement.Points
            })
            .FirstAsync();

        var subtaskDtos = await _context.UserSubtasks
            .Include(us => us.Subtask)
            .Where(us => us.Subtask.AchievementId == achievementId)
            .Select(us => new SubtaskDto
            {
                UserSubtaskId = us.Id,
                Name = us.Subtask.Name,
                Description = us.Subtask.Description,
                CompletedNumber = us.NumberCompleted,
                TotalNumber = us.Subtask.TotalNumber,
                ImagePath = us.Subtask.ImageFile,
                Location = us.Subtask.LocationId,
                ItemId = us.Subtask.ItemId
            })
            .ToListAsync();

        achievementDetailsScreenDto.Subtasks = subtaskDtos;
        return achievementDetailsScreenDto;
    }
}