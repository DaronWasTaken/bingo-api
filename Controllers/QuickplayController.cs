using bingo_api.Models.Entities;
using bingo_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuickplayController : ControllerBase
{
    private readonly IRepository<Quickplay> _quickplayRepository;

    public QuickplayController(IRepository<Quickplay> quickplayRepository)
    {
        _quickplayRepository = quickplayRepository;
    }

    [HttpGet]
    public IActionResult GetQuickplay()
    {
        return Ok(_quickplayRepository.GetAllAsync());
    }
}