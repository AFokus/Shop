public class Processors : ITable
{
    public int ProcID { get; set; }
    public string Platform { get; set; }
    public string Model { get; set; }
    public int Cores { get; set; }
    public int Threads { get; set; }
    public double Frequency { get; set; }
    public double Trubo_Frequency { get; set; }
    public int TDP { get; set; }
    public int GraphicsID { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var procID);
        int.TryParse(parameters[2], out var cores);
        int.TryParse(parameters[3], out var threads);
        double.TryParse(parameters[4], out var frequency);
        double.TryParse(parameters[5], out var trubo_Frequency);
        int.TryParse(parameters[6], out var tDP);
        int.TryParse(parameters[7], out var graphicsID);

        ProcID = procID;
        Platform = parameters[1];
        Model = parameters[2];
        Cores = cores;
        Threads = threads;
        Frequency = frequency;
        Trubo_Frequency = trubo_Frequency;
        TDP = tDP;
        GraphicsID = graphicsID;

        return this;
    }
}
