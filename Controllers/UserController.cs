using System.ComponentModel.DataAnnotations;
using bingo_api.Models.Views;
using bingo_api.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("/levelWidget/{id:int}")]
    public async Task<IActionResult> GetUserLevelWidget(int id)
    {
        LevelWidgetDto levelWidgetDto = await _userService.GetUserLevelWidget(id);
        return Ok(levelWidgetDto);
    }

    //TODO: Include all parameters inside request body
    [HttpPost("{id:int}/quickplay/award")]
    public IActionResult AwardQuickplayObject(int id, [Required] int quickplayObjectId)
    {
        return Ok();
    }
}