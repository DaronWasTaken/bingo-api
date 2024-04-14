using bingo_api.Models;
using bingo_api.Models.DTOs;
using bingo_api.Models.Entities;
using bingo_api.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Services;

public interface IUserService
{
    public Task InitializeNewUserData(User user); 
    public Task<IEnumerable<User>> GetUsersWithQuickplays();
    public Task<LevelWidgetDto> GetUserLevelWidget(string userId);
    public Task<QuickplayScreenDto> GetUserQuickplayScreen(string userId);
    public Task<AchievementScreenDto> GetUserAchievementScreen(string userId);

}