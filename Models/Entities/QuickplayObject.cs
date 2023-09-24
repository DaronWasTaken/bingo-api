namespace bingo_api.Models.Entities;

public class QuickplayObject
{
    public  int QuickplayObjectId { get; set; }
    public int ScanTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ScanDate { get; set; }
    public int Points { get; set; }
}