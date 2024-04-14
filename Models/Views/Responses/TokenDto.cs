namespace bingo_api.Models.Views;

public class TokenDto
{
    public string access_token { get; set; } = null!;
    public string refresh_token { get; set; } = null!;
    public string token_type { get; set; } = "Bearer";
    public int expires_in { get; set; }
}