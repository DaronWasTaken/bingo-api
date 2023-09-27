namespace bingo_api.Services.Level;

public class LevelService : ILevelService
{
    private readonly BingoDevContext _context;
    
    public LevelService(BingoDevContext context)
    {
        _context = context;
    }
}