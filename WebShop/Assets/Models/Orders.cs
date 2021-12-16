public class Orders : ITable
{  
    public int OrderID { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; } 
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    public bool GiftWrap { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var orderID);
        int.TryParse(parameters[6], out var giftWrap);

        OrderID = orderID;
        Name = parameters[1];
        City = parameters[2];
        State = parameters[3];
        Zip = parameters[4];
        Country = parameters[5];
        GiftWrap = giftWrap == 1;

        return this;
    }
}
