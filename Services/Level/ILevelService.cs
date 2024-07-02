using bingo_api.Models.Entities;

namespace bingo_api.Services.Level;

public interface ILevelService
{
    public Task AssignPointsToUser(User user, int points);
}