public class Storage : ITable
{
    public int StorageID { get; set; }
    public int Type { get; set; }
    public string Volume { get; set; }
    public int M_2_Slots { get; set; }
    public string SSD_Interface { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var storageID);
        int.TryParse(parameters[1], out var type);
        int.TryParse(parameters[3], out var m_2_Slots);

        StorageID = storageID;
        Type = type;
        Volume = parameters[2];
        M_2_Slots = m_2_Slots;
        SSD_Interface = parameters[4];

        return this;
    }
}
