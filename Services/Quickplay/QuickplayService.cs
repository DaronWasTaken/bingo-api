using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services.Quickplay;

using Quickplay = bingo_api.Models.Entities.Quickplay;

public class QuickplayService : IQuickplayService
{
    private readonly BingoDevContext _context;

    public QuickplayService(BingoDevContext context)
    {
        _context = context;
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

        if (result != null)
        {
            result.User.Points += result.QuickplayObject.Points;
            
            if (result.User.Points >= result.User.LevelNumberNavigation.RequiredPoints)
            {
                result.User.LevelNumber += 1;
            }
            
            var associatedQuickplayObjectIds = await _context.Quickplays
                .Where(q => q.UserId == result.User.UserId)
                .Select(q => q.QuickplayObject.QuickplayObjectId)
                .ToListAsync();
            
            var newQuickplayObject = await _context.QuickplayObjects
                .Where(qo => !associatedQuickplayObjectIds.Contains(qo.QuickplayObjectId))
                .OrderByDescending(r => r.Points)
                .FirstOrDefaultAsync();
            
            _context.Quickplays.Remove(result.Quickplay);

            if (newQuickplayObject != null)
            {
                var newQuickplay = new Quickplay
                {
                    User = result.User,
                    QuickplayObject = newQuickplayObject
                };
                _context.Quickplays.Add(newQuickplay);
            }
        }

        await _context.SaveChangesAsync();
    }
}