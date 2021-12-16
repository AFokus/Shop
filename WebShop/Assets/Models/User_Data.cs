public class User_Data : ITable
{
    public int UserID { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int Access_Level { get; set; }
    public int CartLineID { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var userID);
        int.TryParse(parameters[3], out var access_Level);
        int.TryParse(parameters[4], out var cartLineID);

        UserID = userID;
        Login = parameters[1];
        Password = parameters[2];
        Access_Level = access_Level;
        CartLineID = cartLineID;

        return this;
    }
}
