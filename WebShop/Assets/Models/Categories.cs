public class Categories : ITable
{
    public int CategoryId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public ITable SetData(string[] parameters)
    {
        int.TryParse(parameters[0], out var categoryId);

        CategoryId = categoryId;
        Type = parameters[1];
        Description = parameters[2];

        return this;
    }
}
