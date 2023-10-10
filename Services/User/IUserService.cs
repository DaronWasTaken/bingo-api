using bingo_api.Models;
using bingo_api.Models.Views;

namespace bingo_api.Services;

public interface IUserService
{
    public Task<IEnumerable<User>> GetUsersWithQuickplays();
    public Task<LevelWidgetDto> GetUserLevelWidget(string id);
    public Task<QuickplayScreenDto> GetUserQuickplayScreen(string userId);
}