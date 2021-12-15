public class ScreenTable : ITable
{
    public int ScreenID { get; set; }
    public string Diagonal { get; set; }
    public string Resolution { get; set; }
    public int Frequency { get; set; }
    public string Surface { get; set; }
    public string Technology { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var screenID);
        int.TryParse(parameters[3], out var frequency);

        ScreenID = screenID;
        Frequency = frequency;
        Diagonal = parameters[1];
        Resolution = parameters[2];
        Surface = parameters[4];
        Technology = parameters[5];

        return this;
    }
}
