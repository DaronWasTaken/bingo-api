using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bingo_api.Models.Views;

public class RegisterUserDto
{
    [JsonPropertyName("username")]
    [Required]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
}