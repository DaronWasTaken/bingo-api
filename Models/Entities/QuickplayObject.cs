using System.Text.Json.Serialization;

namespace bingo_api.Models.Entities;

public class QuickplayObject
{
    public int QuickplayObjectId { get; set; }

    public int ScanTypeId { get; set; }

    public string Name { get; set; }

    public DateOnly ScanDate { get; set; }

    public int Points { get; set; }

    [JsonIgnore]
    public virtual ICollection<Quickplay> Quickplays { get; set; } = new List<Quickplay>();

    public virtual ScanType ScanType { get; set; } = null!;
}
