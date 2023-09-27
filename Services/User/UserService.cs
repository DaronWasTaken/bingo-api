using bingo_api.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services.User;

using Models.Entities;

public class UserService : IUserService
{
    private readonly BingoDevContext _context;
    private readonly IRepository<User> _userRepository;

    public UserService(BingoDevContext context, IRepository<User> userRepository)
    {
        _context = context;
        _userRepository = userRepository;
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
}