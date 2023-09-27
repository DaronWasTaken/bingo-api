namespace bingo_api.Models.Entities;

public class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal Radius { get; set; }

    public virtual ICollection<ScanType> ScanTypes { get; set; } = new List<ScanType>();
}
