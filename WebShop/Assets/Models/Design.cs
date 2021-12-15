public class Design : ITable
{
    public int DesignID { get; set; }
    public string Material { get; set; }
    public string Color { get; set; }
    public int Backlight_Housing { get; set; }
    public int Keyboard_light { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var designID);
        int.TryParse(parameters[3], out var backlight_Housing);
        int.TryParse(parameters[4], out var keyboard_light);

        DesignID = designID;
        Material = parameters[1];
        Color = parameters[2];
        Backlight_Housing = backlight_Housing;
        Keyboard_light = keyboard_light;

        return this;
    }
}
