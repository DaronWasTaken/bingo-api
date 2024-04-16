namespace bingo_api.Models.DTOs;

public class SubtaskDto
{
    public string UserSubtaskId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int CompletedNumber { get; set; }
    public int TotalNumber { get; set; }
    public string? ImagePath { get; set; }
    public string? Location { get; set; }
    public string? ItemId { get; set; }
}