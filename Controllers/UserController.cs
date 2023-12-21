using System.Security.Claims;
using bingo_api.Models;
using bingo_api.Models.Views;
using bingo_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IRepository<User> _userRepository;
    
    public UserController(IUserService userService, IRepository<User> userRepository, UserManager<User> userManager)
    {
        _userService = userService;
        _userRepository = userRepository;
    }
    
    [HttpGet("levelWidget")]
    public async Task<IActionResult> GetUserLevelWidget()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var levelWidgetDto = await _userService.GetUserLevelWidget(userId);
        return Ok(levelWidgetDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        return Ok(await _userRepository.GetByIdAsync(id));
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
    
}