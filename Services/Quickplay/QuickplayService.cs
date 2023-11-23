using bingo_api.Models;
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
        var result = await _context.QuickPlays
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

        var associatedQuickplayObjectIds = await _context.QuickPlays
            .Where(q => q.UserId.Equals(result.User.Id))
            .Select(q => q.QuickplayObject.QuickplayObjectId)
            .ToListAsync();

        var newQuickplayObject = await _context.QuickplayObjects
            .Where(qo => !associatedQuickplayObjectIds.Contains(qo.QuickplayObjectId))
            .OrderByDescending(r => r.Points)
            .FirstOrDefaultAsync();

        _context.QuickPlays.Remove(result.Quickplay);

        if (newQuickplayObject == null)
        {
            throw new Exception("Couldn't assign new quickplayObject to user");
        }
        
        var newQuickplay = new Quickplay
        {
            User = result.User,
            QuickplayObject = newQuickplayObject
        };
        
        _context.QuickPlays.Add(newQuickplay);

        await _context.SaveChangesAsync();
    }
}