using bingo_api.Models.Entities;
using bingo_api.Models.EntityProviders;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuickplayController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetQuickplay(int id)
    {
        return Ok(QuickplayProvider.Quickplay);
    }
}