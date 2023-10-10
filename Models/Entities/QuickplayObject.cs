namespace bingo_api.Models;

public class QuickplayObject
{
    public int QuickplayObjectId { get; set; }

    public int ScantypeId { get; set; }

    public string Name { get; set; } = null!;

    public int Points { get; set; }

    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual ScanType ScanType { get; set; } = null!;
}
