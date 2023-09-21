namespace bingo_api.Models;

public class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal Radius { get; set; }

    public virtual ICollection<ScanObject> ScanObjects { get; set; } = new List<ScanObject>();
}
