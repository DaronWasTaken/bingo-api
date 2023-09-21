namespace bingo_api.Models.DTO;

public class UserDto
{
    public string Username { get; set; } = null!;
    public int Points { get; set; }
    public int Level { get; set; }
    public List<int> AchievementsId { get; set; }
    public List<int> FriendsId { get; set; }

    public UserDto(string username, int points, int level, List<int> achievementsId, List<int> friendsId)
    {
        Username = username;
        Points = points;
        Level = level;
        AchievementsId = achievementsId;
        FriendsId = friendsId;
    }
}