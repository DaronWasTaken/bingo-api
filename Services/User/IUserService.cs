using bingo_api.Models.Views;

namespace bingo_api.Services;

public interface IUserService
{
    public Task<IEnumerable<Models.Entities.User>> GetUsers();
    public Task<LevelWidgetDto> GetUserLevelWidget(int id);
}