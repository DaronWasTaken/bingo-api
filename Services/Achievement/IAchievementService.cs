using bingo_api.Models.Views;

namespace bingo_api.Models.Entities.Services.Achievement;

public interface IAchievementService
{
    public Task AwardSubtaskScan(string userSubtaskId);
    public Task AwardSubtaskLocation(SubtaskLocationDto subtaskLocationDto);
}