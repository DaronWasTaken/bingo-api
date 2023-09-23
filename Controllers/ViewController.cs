using bingo_api.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ViewController : ControllerBase
{
    [HttpGet("levelWidget/{id:int}")]
    public IActionResult getUserLevelWidget(int id)
    {
        var levelWidgetDto = new LevelWidgetDto
        {
            Username = "James",
            Level = 2,
            Points = 2300,
            RequiredPoints = 3000
        };

        return Ok(levelWidgetDto);
    }
        
}