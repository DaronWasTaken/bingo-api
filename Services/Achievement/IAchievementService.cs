namespace bingo_api.Models.Entities.Services.Achievement;

public interface IAchievementService
{
    public Task AwardSubtaskScan(string userSubtaskId);
}