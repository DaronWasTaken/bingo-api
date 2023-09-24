namespace bingo_api.Models.Entities;

public class User
{
    public int UserId { get; set; }
    public Level Level { get; set; } = null!;
    public string Username { get; set; } = null!;
    public int Points { get; set; }
    public int QuickplayId { get; set; }
}