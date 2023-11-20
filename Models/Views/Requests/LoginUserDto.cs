using System.ComponentModel.DataAnnotations;

namespace bingo_api.Models.Views;

public class LoginUserDto
{
    [Required]
    public string grant_type { get; set; } = "password";
    
    [Required, MaxLength(32)]
    public string username { get; set; } = null!;

    [Required, MinLength(8), MaxLength(32)]
    public string password { get; set; } = null!;
}