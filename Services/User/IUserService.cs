using bingo_api.Models.Views;
using bingo_api.Models.Views.Responses;

namespace bingo_api.Services;

public interface IUserService
{
    public Task<IEnumerable<Models.Entities.User>> GetUsers();
    public Task<LevelWidgetDto> GetUserLevelWidget(int id);
    public Task<QuickplayScreenDto> GetUserQuickplayScreen(int userId);
}