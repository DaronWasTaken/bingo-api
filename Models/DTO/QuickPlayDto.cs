namespace bingo_api.Models.DTO;

public class QuickPlayDto
{
    //quickplayId, name, points, scannableobjectId
    public  int Id { get; set; }
    public string Name { get; set; }
    public int points { get; set; }
    public int ScannableObjectId { get; set; }
}