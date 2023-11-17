using bingo_api.Models;
using bingo_api.Models.Views;
using bingo_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

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
    
    [HttpGet("levelWidget/{id}")]
    public async Task<IActionResult> GetUserLevelWidget(string  id)
    {
        LevelWidgetDto levelWidgetDto = await _userService.GetUserLevelWidget(id);
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

    [HttpGet("quickplay/{userId}")]
    public async Task<IActionResult> GetUserQuickplayScreen(string userId)
    {
        return Ok(await _userService.GetUserQuickplayScreen(userId));
    }
    
}