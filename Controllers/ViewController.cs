using bingo_api.Models.Statics;
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
        return Ok(StaticLevelWidgetDto.LevelWidgetDto);
    }
}