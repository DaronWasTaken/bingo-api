using bingo_api.Models.DTO;
using bingo_api.Models.Statics;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        _logger.LogInformation("Getting the user with id: {id}", id);

        var staticLevelWidget = StaticLevelWidgetDto.LevelWidgetDto;
        
        return Ok(staticLevelWidget);
    }

    [HttpPost("{id:int}/awardPoints")]
    public IActionResult AwardPoints(int id, int points)
    {
        StaticLevelWidgetDto.LevelWidgetDto.Points += points;
        return NoContent();
    }
}