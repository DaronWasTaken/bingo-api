namespace bingo_api.Models;

public class AuthToken
{
    public int TokenId { get; set; }

    public string TokenValue { get; set; } = null!;

    public DateTime Expiry { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
