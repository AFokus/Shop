public class StorageTypes : ITable
{   
    public int STID { get; set; }
    public string Type { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var sTID);
        STID = sTID;
        Type = parameters[1];

        return this;
    }
}
