using System.ComponentModel.DataAnnotations;

namespace bingo_api.Models.Views;

public class LoginUserDto
{
    [Required, MaxLength(32)]
    public string Username { get; set; } = null!;

    [Required, MinLength(8), MaxLength(32)]
    public string Password { get; set; } = null!;
}