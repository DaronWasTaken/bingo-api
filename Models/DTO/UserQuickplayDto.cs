namespace bingo_api.Models.DTO;

public class UserQuickplayDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public int UserLevel { get; set; }
    public int UserNextLvlRequiredPoints { get; set; }
    public List<QuickPlayDto> QuickPlayDtos { get; set; }
}