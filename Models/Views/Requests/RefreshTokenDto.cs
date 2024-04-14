using System.Text.Json.Serialization;

namespace bingo_api.Models.Views;

public class RefreshTokenDto
{
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
}