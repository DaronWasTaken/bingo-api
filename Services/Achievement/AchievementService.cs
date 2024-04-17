using bingo_api.Models.Views;
using bingo_api.Services;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Models.Entities.Services.Achievement;

public class AchievementService : IAchievementService
{
    private readonly PostgresContext _context;
    private readonly ILevelService _levelService;

    public AchievementService(PostgresContext context, ILevelService levelService)
    {
        _context = context;
        _levelService = levelService;
    }

    public async Task AwardSubtaskScan(string userSubtaskId)
    {
        var subtask = await _context.UserSubtasks
            .Include(us => us.Subtask)
            .Include(us => us.UserAchievement)
            .Include(us => us.UserAchievement.Achievement)
            .Where(us => us.Id == userSubtaskId)
            .FirstAsync();
        
        if (subtask.NumberCompleted >= subtask.Subtask.TotalNumber)
        {
            throw new ArgumentException("Subtask already completed");
        }

        subtask.NumberCompleted++;
        if (subtask.NumberCompleted < subtask.Subtask.TotalNumber)
        {
            await _context.SaveChangesAsync();
            return;
        }
        
        subtask.UserAchievement.CompletedSubtasks++;
        if (subtask.UserAchievement.CompletedSubtasks < subtask.UserAchievement.Achievement.TotalSubtasks)
        {
            await _context.SaveChangesAsync();
            return;
        }

        subtask.UserAchievement.CompletionDate = DateTime.UtcNow;
        
        var user = await _context.Users
            .Include(u => u.Level)
            .Where(u => u.Id == subtask.UserAchievement.UserId)
            .FirstAsync();
        
        await _levelService.AssignPointsToUser(user, subtask.UserAchievement.Achievement.Points);
        await _context.SaveChangesAsync();
    }

    public async Task AwardSubtaskLocation(SubtaskLocationDto subtaskLocationDto)
    {
            
    }
}