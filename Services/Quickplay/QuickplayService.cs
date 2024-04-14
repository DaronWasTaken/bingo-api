using bingo_api.Models;
using bingo_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers;

namespace bingo_api.Services;

public class QuickplayService : IQuickplayService
{
    private readonly PostgresContext _context;
    private readonly ILevelService _levelService;

    public QuickplayService(PostgresContext context, ILevelService levelService)
    {
        _context = context;
        _levelService = levelService;
    }

    public async Task AwardQuickplay(string id)
    {
        var result = await _context.UserItems
            .Where(q => q.Id == id)
            .Include(q => q.User.Level)
            .Select(q => new
            {
                UserItem = q,
                q.Item,
                q.User
            })
            .FirstOrDefaultAsync();

        if (result == null)
        {
            throw new KeyNotFoundException("Quickplay was not found");
        }

        await _levelService.AssignPointsToUser(result.User, result.Item.Points);

        var otherQuickplayItemIds = await _context.UserItems
            .Where(q => q.UserId.Equals(result.User.Id))
            .Select(q => q.Item.Id)
            .ToListAsync();

        var nextItem = await _context.Items
            .Where(qo => !otherQuickplayItemIds.Contains(qo.Id))
            .OrderByDescending(r => r.Points)
            .FirstOrDefaultAsync();

        _context.UserItems.Remove(result.UserItem);

        if (nextItem == null)
        {
            throw new Exception("Couldn't assign new quickplayObject to user");
        }
        
        var newQuickplayItem = new UserItem
        {
            Id = Guid.NewGuid().ToString(),
            User = result.User,
            Item = nextItem
        };
        
        _context.UserItems.Add(newQuickplayItem);

        await _context.SaveChangesAsync();
    }
}