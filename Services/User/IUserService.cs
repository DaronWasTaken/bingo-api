using bingo_api.Models.Views;

namespace bingo_api.Services.User;

public interface IUserService
{
    public Task<LevelWidgetDto> GetUserLevelWidget(int id);
}