using bingo_api.Models.Views;
using Task = bingo_api.Models.Entities.Task;

namespace bingo_api.Services.User;

public interface IUserService
{
    public Task<LevelWidgetDto> GetUserLevelWidget(int id);
    public void AwardUserQuickplay(int userId, int quickplayObjectId);
}