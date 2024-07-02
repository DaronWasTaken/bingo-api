using System.Security.Claims;
using bingo_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("levelWidget")]
    public async Task<IActionResult> GetUserLevelWidget()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var levelWidgetDto = await _userService.GetUserLevelWidget(userId);
        return Ok(levelWidgetDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userService.GetUsersWithQuickplays());
    }

    [HttpGet("quickplay")]
    public async Task<IActionResult> GetUserQuickplayScreen()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(await _userService.GetUserQuickplayScreen(userId));
    }

    [HttpGet("achievement")]
    public async Task<IActionResult> GetUserAchievementScreen()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(await _userService.GetUserAchievementScreen(userId));
    }

    [HttpGet("achievement/{achievementId:int}")]
    public async Task<IActionResult> GetUserAchievementDetailsScreen([FromRoute] int achievementId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(await _userService.GetUserAchievementDetailsScreen(userId, achievementId));
    }
    
}