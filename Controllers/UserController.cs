using bingo_api.Models.Entities;
using bingo_api.Models.Views;
using bingo_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;
    private readonly IRepository<User> _userRepository;

    public UserController(IUserService userService, IRepository<User> userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }

    [HttpGet("levelWidget/{id:int}")]
    public async Task<IActionResult> GetUserLevelWidget(int id)
    {
        LevelWidgetDto levelWidgetDto = await _userService.GetUserLevelWidget(id);
        return Ok(levelWidgetDto);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(await _userRepository.GetByIdAsync(id));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userService.GetUsers());
    }
    
}