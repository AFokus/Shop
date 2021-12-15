public partial class Models : ITable
{
    public int ModelId { get; set; }
    public string Name { get; set; }
    public string Options { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public string Release_Date { get; set; }
    public int CPUID { get; set; }
    public int DesignID { get; set; }
    public int Weight { get; set; }
    public int ScreenID { get; set; }
    public int RAMID { get; set; }
    public int StorageID { get; set; }
    public int GraphicsID { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var modelID);
        int.TryParse(parameters[3], out var price);
        int.TryParse(parameters[4], out var categoryID);
        int.TryParse(parameters[6], out var cpuID);
        int.TryParse(parameters[7], out var designID);
        int.TryParse(parameters[8], out var weight);
        int.TryParse(parameters[9], out var screenID);
        int.TryParse(parameters[10], out var ramID);
        int.TryParse(parameters[11], out var storageID);
        int.TryParse(parameters[12], out var graphicID);

        Name = parameters[1];
        Options = parameters[2];
        Release_Date = parameters[5];

        ModelId = modelID;
        Price = price;
        CategoryId = categoryID;
        CPUID = cpuID;
        DesignID = designID;
        Weight = weight;
        ScreenID = screenID;
        RAMID = ramID;
        StorageID = storageID;
        GraphicsID = graphicID;


        return this;
    }
}
