using bingo_api.Models.Entities;
using bingo_api.Services;
using bingo_api.Services.Quickplay;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuickplayController : ControllerBase
{
    private readonly IRepository<Quickplay> _quickplayRepository;
    private readonly IQuickplayService _quickplayService;
    public QuickplayController(IRepository<Quickplay> quickplayRepository, IQuickplayService quickplayService)
    {
        _quickplayRepository = quickplayRepository;
        _quickplayService = quickplayService;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuickplay()
    {
        return Ok(await _quickplayRepository.GetAllAsync());
    }

    [HttpPost("award/{quickplayId:int}")]
    public async Task<IActionResult> AwardQuickplayByQuickplayId(int quickplayId)
    {
        await _quickplayService.AwardQuickplay(quickplayId);
        return NoContent();
    }
}