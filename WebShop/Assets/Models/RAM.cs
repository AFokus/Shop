public class RAM : ITable
{
    public int RAMID;
    public string Type;
    public int Frequency;
    public int Volume;
    public int FreeSlots;

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var rAMID);
        int.TryParse(parameters[2], out var frequency);
        int.TryParse(parameters[3], out var volume);
        int.TryParse(parameters[4], out var freeSlots);

        RAMID = rAMID;
        Frequency = frequency;
        Volume = volume;
        FreeSlots = freeSlots;
        Type = parameters[1];

        return this;
    }
}
