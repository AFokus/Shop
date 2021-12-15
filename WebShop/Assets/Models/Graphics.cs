public class GraphicsTable : ITable
{
    public int GraphicId { get; set; }
    public string Name { get; set; }
    public int Volume { get; set; }
    public string Interface { get; set; }
    public int Frequency { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var graphicId);
        int.TryParse(parameters[2], out var volume);
        int.TryParse(parameters[4], out var frequency);

        GraphicId = graphicId;
        Name = parameters[1];
        Volume = volume;
        Interface = parameters[3];
        Frequency = frequency;

        return this;
    }
}