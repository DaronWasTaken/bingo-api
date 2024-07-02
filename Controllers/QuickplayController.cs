using bingo_api.Models;
using bingo_api.Services;
using bingo_api.Services.Quickplay;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuickplayController : ControllerBase
{
    private readonly IQuickplayService _quickplayService;
    public QuickplayController(IQuickplayService quickplayService)
    {
        _quickplayService = quickplayService;
    }
    
    [HttpPost("award/{id}")]
    public async Task<IActionResult> AwardQuickplayByQuickplayId(string id)
    {
        await _quickplayService.AwardQuickplay(id);
        return NoContent();
    }
}