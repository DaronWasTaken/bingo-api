namespace bingo_api.Models.DTO;

public class UserDto
{
    public string Username { get; set; } = null!;
    public int Level { get; set; }
    public int Points { get; set; }
    public List<int> AchievementsId { get; set; }

    public UserDto(string username, int points, int level, List<int> achievementsId)
    {
        Username = username;
        Points = points;
        Level = level;
        AchievementsId = achievementsId;
    }
}