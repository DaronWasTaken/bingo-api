using bingo_api.Services.Quickplay;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services;

public class QuickplayService : IQuickplayService
{
    private readonly BingoDevContext _context;
    private readonly ILevelService _levelService;

    public QuickplayService(BingoDevContext context, ILevelService levelService)
    {
        _context = context;
        _levelService = levelService;
    }

    public async Task AwardQuickplay(int id)
    {
        var result = await _context.Quickplays
            .Where(q => q.QuickplayId == id)
            .Include(q => q.User.LevelNumberNavigation)
            .Select(q => new
            {
                Quickplay = q,
                q.QuickplayObject,
                q.User
            })
            .FirstOrDefaultAsync();

        if (result == null)
        {
            throw new KeyNotFoundException("Quickplay was not found");
        }

        await _levelService.AssignPointsToUser(result.User, result.QuickplayObject.Points);

        var associatedQuickplayObjectIds = await _context.Quickplays
            .Where(q => q.UserId == result.User.UserId)
            .Select(q => q.QuickplayObject.QuickplayObjectId)
            .ToListAsync();

        var newQuickplayObject = await _context.QuickplayObjects
            .Where(qo => !associatedQuickplayObjectIds.Contains(qo.QuickplayObjectId))
            .OrderByDescending(r => r.Points)
            .FirstOrDefaultAsync();

        _context.Quickplays.Remove(result.Quickplay);

        if (newQuickplayObject == null)
        {
            throw new Exception("Couldn't assign new quickplayObject to user");
        }
        
        var newQuickplay = new Models.Entities.Quickplay
        {
            User = result.User,
            QuickplayObject = newQuickplayObject
        };
        
        _context.Quickplays.Add(newQuickplay);

        await _context.SaveChangesAsync();
    }
}