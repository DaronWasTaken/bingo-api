using bingo_api.Models.Entities;

namespace bingo_api.Models.EntityProviders;

public static class QuickplayObjectListProvider
{
    static QuickplayObject _quickplayObject = new()
    {
        QuickplayObjectId = 1,
        Name = "Balloon",
        Points = 200,
        ScanTypeId = 2
    };
        
    static QuickplayObject _quickplayObjectDto2 = new()
    {
        QuickplayObjectId = 2,
        Name = "Car",
        Points = 100,
        ScanTypeId = 1
    };
        
    static QuickplayObject _quickplayObjectDto3 = new()
    {
        QuickplayObjectId = 3,
        Name = "Bird",
        Points = 200,
        ScanTypeId = 3
    };
    
    static QuickplayObject _quickplayObjectDto4 = new()
    {
        QuickplayObjectId = 4,
        Name = "Chair",
        Points = 100,
        ScanTypeId = 4
    };
    
    static QuickplayObject _quickplayObjectDto5 = new()
    {
        QuickplayObjectId = 5,
        Name = "Carrot",
        Points = 250,
        ScanTypeId = 5
    };
    
    static QuickplayObject _quickplayObjectDto6 = new()
    {
        QuickplayObjectId = 6,
        Name = "Pineapple",
        Points = 400,
        ScanTypeId = 5
    };
    
    public static List<QuickplayObject> QuickplayObjects { get; set; } = new() { _quickplayObject, _quickplayObjectDto2, _quickplayObjectDto3, _quickplayObjectDto4, _quickplayObjectDto5, _quickplayObjectDto6 };
}