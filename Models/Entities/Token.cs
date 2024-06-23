using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bingo_api.Models.Entities;

public class Token
{
    [Key, ForeignKey("User")]
    public string UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime AccessExpiresAt { get; set; }
    public DateTime RefreshExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
}