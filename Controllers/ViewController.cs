using bingo_api.Models.Entities;
using bingo_api.Models.EntityProviders;
using bingo_api.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ViewController : ControllerBase
{
    [HttpGet("levelWidget/{id:int}")]
    public IActionResult GetUserLevelWidget(int id)
    {
        var user = UserProvider.User;
        var levelWidgetDto = new LevelWidgetDto
        {
            Username = user.Username,
            Level = user.Level.LevelNumber,
            Points = user.Points,
            RequiredPoints = user.Level.RequiredPoints
        };
        return Ok(levelWidgetDto);
    }
}